define(['jquery', 'knockout'], function ($, ko) {

	var search = {
		configs: {
			filter: function (filterText) {
			}
		},
		init: function (configs) {
			var _this = search;
			$.extend(_this.configs, configs);
			ko.applyBindings(_this.viewModel, $(".flextable.table-actions")[0]);
		},		
		viewModel : {
			filterText: ko.observable(""),
			onFilterTextKeyUp: function (d, e) {
				var _this = this;
				if (e.keyCode == 13) {
					search.configs.filter(_this.filterText());
					return false; // ignore default event
				}
				return false;
			},
			onFilterTextBlur: function (d, e) {
				var _this = this;
			//	search.configs.filter(_this.filterText());
				return false; // ignore default event
			},
			onSearchBtnClick: function (annexContractCode) {
				var _this = this;
				search.configs.filter(_this.filterText());
				return false; // ignore default event
			},
			onClearFilterClick: function (d, e) {
				var _this = this;
				_this.filterText("");
				search.configs.filter(_this.filterText());
			}
		},

	}
	return {
		init: search.init,
	}
});
