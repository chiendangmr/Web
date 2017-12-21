using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using HD.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Diagnostics;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HD.TVAD.Web.Features.Language.Translator
{
    [Area("Tools")]
    [Route("api/tools/[controller]/[action]")]
    public class TranslatorWebApiController : Controller
    {
        private readonly LocalizationDbContext _context;
        private readonly IStringLocalizer<TranslatorWebApiController> localizer_;
        public TranslatorWebApiController(LocalizationDbContext context, IStringLocalizer<TranslatorWebApiController> localizer)
        {
            _context = context;
            localizer_ = localizer;
        }

        // GET: api/values
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            #region Old
            //var datas = from result in (
            //        from origin_with_culture in (
            //            from origin in _context.LocalizableTexts
            //            from culture in _context.Cultures
            //            where !culture.Disabled && culture.Parent == null
            //            select new
            //            {
            //                origin.Id,
            //                origin.Key,
            //                origin.Scope,
            //                Culture = culture.Name
            //            })
            //        join translator in (from t in _context.LocalizedTexts where !t.Disabled select t)
            //            on new { origin_with_culture.Key, origin_with_culture.Scope, origin_with_culture.Culture } equals new { translator.Key, translator.Scope, translator.Culture }
            //            into joined
            //        from j in joined.DefaultIfEmpty()
            //        select new
            //        {
            //            origin_with_culture.Id,
            //            origin_with_culture.Key,
            //            origin_with_culture.Scope,
            //            origin_with_culture.Culture,
            //            Value = j == null ? null : j.Value
            //        })
            //            group result by new { result.Id, result.Key, result.Scope } into grouped
            //            select new
            //            {
            //                grouped.Key.Id,
            //                grouped.Key.Key,
            //                grouped.Key.Scope,
            //                Translators = grouped.Select(g => new { Key = g.Culture, g.Value })
            //            };
            //List<dynamic> lstResult = new List<dynamic>();
            //foreach (var data in datas.Take(10).ToList())
            //{
            //    IDictionary<string, object> eo = new ExpandoObject() as IDictionary<string, object>;
            //    eo.Add("Id", data.Id);
            //    eo.Add("Key", data.Key);
            //    eo.Add("Scope", string.IsNullOrWhiteSpace(data.Scope) ? "(" + localizer_["global"].Value + ")" : data.Scope);
            //    foreach (var culture in data.Translators)
            //    {
            //        eo.Add(culture.Key, culture.Value);
            //    }
            //    lstResult.Add(eo);
            //}
            #endregion

            #region User Dynamic entity
            //var baseCultures = _context.Cultures.Where(c => !c.Disabled && c.Parent == null).ToList();
            //Dictionary<string, string> languages = new Dictionary<string, string>();
            //int nbLang = 0;
            //baseCultures.ForEach(c => languages.Add(c.Name, $"Lang{++nbLang}"));
            //var sqlColumns = string.Join(",", languages.Select(l => $"[{l.Key}]"));
            //var toObjectColumns = string.Join(",", languages.Select(l => $"[{l.Key}] as {l.Value}"));
            //for (int n = nbLang + 1; n <= TranslatorView.MaxLang; ++n)
            //    toObjectColumns += $", N'' as Lang{n}";
            //string resultColums = "new(Id,Scope,Key," + string.Join(",", languages.Select(l => l.Value + " as " + l.Key)) + ")";

            //var query = (_context.TranslatorViews.FromSql(@"Select Id, [Key], Scope = case Scope when N'' then N'(global)' else Scope end," + toObjectColumns + @"
            //    From
            //    (Select LocalizableTexts.Id, LocalizableTexts.[Key], LocalizableTexts.Scope, LocalizedTexts.Culture, LocalizedTexts.Value
            //        From Language.LocalizableTexts
            //        Left Join Language.LocalizedTexts On LocalizedTexts.[Key] = LocalizableTexts.[Key] And LocalizedTexts.Scope = LocalizableTexts.Scope
            //    ) As SourceTable
            //    PIVOT(MAX(Value)
            //     FOR Culture IN(" + sqlColumns + ")) As PVTable")
            //     .Select(resultColums) as IQueryable<dynamic>).ToList();

            //var res = DataSourceLoader.Load(query, loadOptions);
            //return res;
            #endregion

            using (var con = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var translators = con.Query(@"Declare @cultures nvarchar(256) = N''
                Select @cultures = @cultures + N'[' + [Name] + N'],' From Language.Cultures Where Disabled = 0 And Parent is null
                Set @cultures = LEFT(@cultures, len(@cultures) - 1)
                Declare @DynamicQuery nvarchar(MAX)
                Set @DynamicQuery =
                 N'Select Id, [Key], Scope = case Scope when N'''' then N''(global)'' else Scope end, '+@cultures+N'
                 From
                 (Select LocalizableTexts.Id, LocalizableTexts.[Key], LocalizableTexts.Scope, LocalizedTexts.Culture, LocalizedTexts.Value
                  From Language.LocalizableTexts
                  Left Join Language.LocalizedTexts On LocalizedTexts.[Key] = LocalizableTexts.[Key] And LocalizedTexts.Scope = LocalizableTexts.Scope
                 ) As SourceTable
                 PIVOT(MAX(Value)
                 FOR Culture IN('+@cultures+N')) As PVTable'
                EXEC sp_executesql @DynamicQuery");

                return DataSourceLoader.Load(translators, loadOptions);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            try
            {
                var origin = await _context.LocalizableTexts.FindAsync(key);

                var translators = JsonConvert.DeserializeObject<Dictionary<string, string>>(values);

                var olds = await _context.LocalizedTexts.Where(t => !t.Disabled && t.Key == origin.Key && t.Scope == origin.Scope).ToListAsync();

                foreach (var translator in translators)
                {
                    var old = olds.FirstOrDefault(t => t.Culture == translator.Key);
                    if (old == null)
                    {
                        _context.LocalizedTexts.Add(new LocalizedText()
                        {
                            Key = origin.Key,
                            Scope = origin.Scope,
                            Culture = translator.Key,
                            Disabled = false,
                            Value = translator.Value
                        });
                    }
                    else if (old.Value != translator.Value)
                        old.Value = translator.Value;
                }

                await _context.SaveChangesAsync();

                var changedLang = Encoding.UTF8.GetBytes("true");
                HttpContext.Session.Set("ChangedLanguage", changedLang);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int key)
        {
            try
            {
                var origin = await _context.LocalizableTexts.FindAsync(key);

                _context.LocalizedTexts.RemoveRange(_context.LocalizedTexts.Where(t => t.Key == origin.Key && t.Scope == origin.Scope));

                _context.LocalizableTexts.Remove(origin);

                await _context.SaveChangesAsync();

                var changedLang = Encoding.UTF8.GetBytes("true");
                HttpContext.Session.Set("ChangedLanguage", changedLang);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class MyClassBuilder
    {
        public object CreateObject(string[] PropertyNames, Type[] Types)
        {
            if (PropertyNames.Length != Types.Length)
            {
                Console.WriteLine("The number of property names should match their corresopnding types number");
            }

            TypeBuilder DynamicClass = this.GetTypeBuilder();
            this.CreateConstructor(DynamicClass);
            for (int ind = 0; ind < PropertyNames.Count(); ind++)
                CreateProperty(DynamicClass, PropertyNames[ind], Types[ind]);
            var info = DynamicClass.CreateTypeInfo();
            var type = info.AsType();

            return Activator.CreateInstance(type);
        }
        private TypeBuilder GetTypeBuilder()
        {
            var typeSignature = "TranslatorViewCulture";
            var an = new AssemblyName(typeSignature);
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(Guid.NewGuid().ToString()), AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
            TypeBuilder tb = moduleBuilder.DefineType(typeSignature,
                    TypeAttributes.Public |
                    TypeAttributes.Class |
                    TypeAttributes.AutoClass |
                    TypeAttributes.AnsiClass |
                    TypeAttributes.BeforeFieldInit |
                    TypeAttributes.AutoLayout,
                    null);
            return tb;
        }

        private void CreateConstructor(TypeBuilder typeBuilder)
        {
            typeBuilder.DefineDefaultConstructor(MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
        }
        private void CreateProperty(TypeBuilder typeBuilder, string propertyName, Type propertyType)
        {
            FieldBuilder fieldBuilder = typeBuilder.DefineField("_" + propertyName, propertyType, FieldAttributes.Private);

            PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(propertyName, PropertyAttributes.HasDefault, propertyType, null);
            MethodBuilder getPropMthdBldr = typeBuilder.DefineMethod("get_" + propertyName, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, propertyType, Type.EmptyTypes);
            ILGenerator getIl = getPropMthdBldr.GetILGenerator();

            getIl.Emit(OpCodes.Ldarg_0);
            getIl.Emit(OpCodes.Ldfld, fieldBuilder);
            getIl.Emit(OpCodes.Ret);

            MethodBuilder setPropMthdBldr = typeBuilder.DefineMethod("set_" + propertyName,
                  MethodAttributes.Public |
                  MethodAttributes.SpecialName |
                  MethodAttributes.HideBySig,
                  null, new[] { propertyType });

            ILGenerator setIl = setPropMthdBldr.GetILGenerator();
            Label modifyProperty = setIl.DefineLabel();
            Label exitSet = setIl.DefineLabel();

            setIl.MarkLabel(modifyProperty);
            setIl.Emit(OpCodes.Ldarg_0);
            setIl.Emit(OpCodes.Ldarg_1);
            setIl.Emit(OpCodes.Stfld, fieldBuilder);

            setIl.Emit(OpCodes.Nop);
            setIl.MarkLabel(exitSet);
            setIl.Emit(OpCodes.Ret);

            propertyBuilder.SetGetMethod(getPropMthdBldr);
            propertyBuilder.SetSetMethod(setPropMthdBldr);
        }
    }
}