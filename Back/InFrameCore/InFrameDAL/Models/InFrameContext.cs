using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InFrameDAL.Models
{
    public partial class InFrameContext : DbContext
    {
        public InFrameContext()
        {
        }

        public InFrameContext(DbContextOptions<InFrameContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Demand> Demand { get; set; }
        public virtual DbSet<DemandDynProp> DemandDynProp { get; set; }
        public virtual DbSet<DemandDynPropValue> DemandDynPropValue { get; set; }
        public virtual DbSet<DemandDynPropValueHisto> DemandDynPropValueHisto { get; set; }
        public virtual DbSet<DemandTransitionHisto> DemandTransitionHisto { get; set; }
        public virtual DbSet<DemandType> DemandType { get; set; }
        public virtual DbSet<DemandTypeDemandDynProp> DemandTypeDemandDynProp { get; set; }
        public virtual DbSet<FormConfig> FormConfig { get; set; }
        public virtual DbSet<FormField> FormField { get; set; }
        public virtual DbSet<FormGroup> FormGroup { get; set; }
        public virtual DbSet<Transition> Transition { get; set; }
        public virtual DbSet<TransitionStartState> TransitionStartState { get; set; }
        public virtual DbSet<WorkFlow> WorkFlow { get; set; }
        public virtual DbSet<WorkFlowTransition> WorkFlowTransition { get; set; }
        public virtual DbSet<WorkflowState> WorkflowState { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=InFrame;Trusted_Connection=True;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Demand>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasColumnName("author")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TypeId).HasColumnName("typeId");

                entity.Property(e => e.WorkFlowId).HasColumnName("workFlowId");

                entity.Property(e => e.WorkflowStateId).HasColumnName("workflowStateId");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Demand)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Demand_demandTypeId");

                entity.HasOne(d => d.WorkFlow)
                    .WithMany(p => p.Demand)
                    .HasForeignKey(d => d.WorkFlowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Demand_workflowId");

                entity.HasOne(d => d.WorkflowState)
                    .WithMany(p => p.Demand)
                    .HasForeignKey(d => d.WorkflowStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Demand_workflowStateId");
            });

            modelBuilder.Entity<DemandDynProp>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.DynPropName)
                    .IsRequired()
                    .HasColumnName("dynPropName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DynPropType)
                    .IsRequired()
                    .HasColumnName("dynPropType")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DemandDynPropValue>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChangeDate)
                    .HasColumnName("changeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DemandId).HasColumnName("demandId");

                entity.Property(e => e.DynPropId).HasColumnName("dynPropId");

                entity.Property(e => e.ValueDate)
                    .HasColumnName("valueDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ValueDecimal)
                    .HasColumnName("valueDecimal")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ValueGeom)
                    .HasColumnName("valueGeom")
                    .HasColumnType("geometry");

                entity.Property(e => e.ValueInt).HasColumnName("valueInt");

                entity.Property(e => e.ValueReal).HasColumnName("valueReal");

                entity.Property(e => e.ValueString)
                    .HasColumnName("valueString")
                    .IsUnicode(false);

                entity.HasOne(d => d.Demand)
                    .WithMany(p => p.DemandDynPropValue)
                    .HasForeignKey(d => d.DemandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DemandDynPropValue_demandId");

                entity.HasOne(d => d.DynProp)
                    .WithMany(p => p.DemandDynPropValue)
                    .HasForeignKey(d => d.DynPropId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DemandDynPropValue_dynPropId");
            });

            modelBuilder.Entity<DemandDynPropValueHisto>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChangeDate)
                    .HasColumnName("changeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DemandId).HasColumnName("demandId");

                entity.Property(e => e.DynPropId).HasColumnName("dynPropId");

                entity.Property(e => e.ValueDate)
                    .HasColumnName("valueDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ValueDecimal)
                    .HasColumnName("valueDecimal")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ValueGeom)
                    .HasColumnName("valueGeom")
                    .HasColumnType("geometry");

                entity.Property(e => e.ValueInt).HasColumnName("valueInt");

                entity.Property(e => e.ValueReal).HasColumnName("valueReal");

                entity.Property(e => e.ValueString)
                    .HasColumnName("valueString")
                    .IsUnicode(false);

                entity.HasOne(d => d.Demand)
                    .WithMany(p => p.DemandDynPropValueHisto)
                    .HasForeignKey(d => d.DemandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DemandDynPropValueHisto_demandId");

                entity.HasOne(d => d.DynProp)
                    .WithMany(p => p.DemandDynPropValueHisto)
                    .HasForeignKey(d => d.DynPropId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DemandDynPropValueHisto_dynPropId");
            });

            modelBuilder.Entity<DemandTransitionHisto>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment).IsUnicode(false);

                entity.Property(e => e.DemandId).HasColumnName("demandId");

                entity.Property(e => e.TransitionDate)
                    .HasColumnName("transitionDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TransitionId).HasColumnName("transitionId");

                entity.HasOne(d => d.Demand)
                    .WithMany(p => p.DemandTransitionHisto)
                    .HasForeignKey(d => d.DemandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DemandTransitionHisto_demandId");

                entity.HasOne(d => d.Transition)
                    .WithMany(p => p.DemandTransitionHisto)
                    .HasForeignKey(d => d.TransitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkDemandTransitionHisto_transitionId");
            });

            modelBuilder.Entity<DemandType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.TypeDescription)
                    .HasColumnName("typeDescription")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.TypeInternalName)
                    .IsRequired()
                    .HasColumnName("typeInternalName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasColumnName("typeName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TypeShortName)
                    .IsRequired()
                    .HasColumnName("typeShortName")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WorkflowId).HasColumnName("workflowId");

                entity.HasOne(d => d.Workflow)
                    .WithMany(p => p.DemandType)
                    .HasForeignKey(d => d.WorkflowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DemandType_workflowId");
            });

            modelBuilder.Entity<DemandTypeDemandDynProp>(entity =>
            {
                entity.ToTable("DemandType_DemandDynProp");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.DynPropId).HasColumnName("dynPropId");

                entity.Property(e => e.TypeId).HasColumnName("typeId");

                entity.HasOne(d => d.DynProp)
                    .WithMany(p => p.DemandTypeDemandDynProp)
                    .HasForeignKey(d => d.DynPropId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DemandType_DemandDynProp_dynPropId");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.DemandTypeDemandDynProp)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DemandType_DemandDynProp_typeId");
            });

            modelBuilder.Entity<FormConfig>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Behavior).HasColumnName("behavior");

                entity.Property(e => e.ColumnNumber).HasColumnName("columnNumber");

                entity.Property(e => e.CssClass)
                    .HasColumnName("cssClass")
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TypeId).HasColumnName("typeId");

                entity.Property(e => e.ValidationMessage)
                    .HasColumnName("validationMessage")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.FormConfig)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_FormConfig_demandTypeId");
            });

            modelBuilder.Entity<FormField>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Behavior).HasColumnName("behavior");

                entity.Property(e => e.CssClass)
                    .HasColumnName("cssClass")
                    .IsUnicode(false);

                entity.Property(e => e.DefaultValue)
                    .IsRequired()
                    .HasColumnName("defaultValue")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FieldLabel)
                    .IsRequired()
                    .HasColumnName("fieldLabel")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FieldName)
                    .IsRequired()
                    .HasColumnName("fieldName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FieldOrder).HasColumnName("fieldOrder");

                entity.Property(e => e.FieldParameters)
                    .IsRequired()
                    .HasColumnName("fieldParameters")
                    .IsUnicode(false);

                entity.Property(e => e.FieldType)
                    .IsRequired()
                    .HasColumnName("fieldType")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FormGroupId).HasColumnName("formGroupId");

                entity.Property(e => e.IsDynamic).HasColumnName("isDynamic");

                entity.Property(e => e.Tooltip)
                    .IsRequired()
                    .HasColumnName("tooltip")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WorkflowStateId).HasColumnName("workflowStateId");

                entity.HasOne(d => d.FormGroup)
                    .WithMany(p => p.FormField)
                    .HasForeignKey(d => d.FormGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_FormField_formGroupId");

                entity.HasOne(d => d.WorkflowState)
                    .WithMany(p => p.FormField)
                    .HasForeignKey(d => d.WorkflowStateId)
                    .HasConstraintName("fk_FormField_workflowStateId");
            });

            modelBuilder.Entity<FormGroup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Behavior).HasColumnName("behavior");

                entity.Property(e => e.ColumnIndex).HasColumnName("columnIndex");

                entity.Property(e => e.CssClass)
                    .HasColumnName("cssClass")
                    .IsUnicode(false);

                entity.Property(e => e.FormConfigId).HasColumnName("formConfigId");

                entity.Property(e => e.GroupOrder).HasColumnName("groupOrder");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.FormConfig)
                    .WithMany(p => p.FormGroup)
                    .HasForeignKey(d => d.FormConfigId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_FormGroup_formConfigId");
            });

            modelBuilder.Entity<Transition>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Actions)
                    .HasColumnName("actions")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.AffichagePriority).HasColumnName("affichagePriority");

                entity.Property(e => e.Behavior).HasColumnName("behavior");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.EndStateId).HasColumnName("endStateId");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.InternalName)
                    .IsRequired()
                    .HasColumnName("internalName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TransitionName)
                    .IsRequired()
                    .HasColumnName("transitionName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TransitionShortName)
                    .IsRequired()
                    .HasColumnName("transitionShortName")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.EndState)
                    .WithMany(p => p.Transition)
                    .HasForeignKey(d => d.EndStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Transition_endStateId");
            });

            modelBuilder.Entity<TransitionStartState>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.StartStateId).HasColumnName("startStateId");

                entity.Property(e => e.TransitionId).HasColumnName("transitionId");

                entity.HasOne(d => d.StartState)
                    .WithMany(p => p.TransitionStartState)
                    .HasForeignKey(d => d.StartStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TransitionStartState_startStateId");

                entity.HasOne(d => d.Transition)
                    .WithMany(p => p.TransitionStartState)
                    .HasForeignKey(d => d.TransitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TransitionStartState_transitionId");
            });

            modelBuilder.Entity<WorkFlow>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.StartStateId).HasColumnName("startStateId");

                entity.Property(e => e.WorkflowDescription)
                    .HasColumnName("workflowDescription")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.WorkflowName)
                    .IsRequired()
                    .HasColumnName("workflowName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.WorkflowShortName)
                    .IsRequired()
                    .HasColumnName("workflowShortName")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.StartState)
                    .WithMany(p => p.WorkFlow)
                    .HasForeignKey(d => d.StartStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_WorkFlow_startStateId");
            });

            modelBuilder.Entity<WorkFlowTransition>(entity =>
            {
                entity.ToTable("WorkFlow_Transition");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.TransitionId).HasColumnName("transitionId");

                entity.Property(e => e.WorkflowId).HasColumnName("workflowId");

                entity.HasOne(d => d.Transition)
                    .WithMany(p => p.WorkFlowTransition)
                    .HasForeignKey(d => d.TransitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_WorkFlow_Transition_transitionId");

                entity.HasOne(d => d.Workflow)
                    .WithMany(p => p.WorkFlowTransition)
                    .HasForeignKey(d => d.WorkflowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_WorkFlow_Transition_workflowId");
            });

            modelBuilder.Entity<WorkflowState>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.StateDescription)
                    .HasColumnName("stateDescription")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasColumnName("stateName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StateShortName)
                    .IsRequired()
                    .HasColumnName("stateShortName")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
