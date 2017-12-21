using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Workflow
{
    [Table("WorkflowDiagram", Schema = "Workflow")]
    public class Diagram
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(2048)]
        public string Description { get; set; }

        public byte[] Revision { get; set; }

        public bool Disabled { get; set; }

        public Guid? WorkflowDiagramVersionId { get; set; }

        [ForeignKey(nameof(WorkflowDiagramVersionId))]
        public DiagramVersion CurrentVersion { get; set; }

        [ForeignKey(nameof(DiagramVersion.WorkflowDiagramId))]
        public ICollection<DiagramVersion> Versions { get; } = new HashSet<DiagramVersion>();
    }
}
