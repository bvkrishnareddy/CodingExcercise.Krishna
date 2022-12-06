namespace Retalix.Jumbo.Contracts.Generated.TestTouchPointKR
{
    using Retalix.Contracts.Generated.Common;
    using Retalix.Contracts.Generated.Arts.PosLogV6.Source;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BatchContractGenerator.Console", "14.100.999")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://retalix.com/R10/services")]
    [System.Xml.Serialization.XmlRootAttribute("TestTouchPointConfigurationMaintenanceRequest", Namespace="http://retalix.com/R10/services", IsNullable=false)]
    public partial class TestTouchPointConfigurationMaintenanceRequestType : Retalix.Contracts.Interfaces.IHeaderRequest
    {
        
        private RetalixCommonHeaderType headerField;
        
        private TestTouchPointConfigurationType[] testTouchPointConfigurationField;
        
        private ActionTypeCodes actionField;
        
        private bool ActionFieldSpecified;
        
        public RetalixCommonHeaderType Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute("TestTouchPointConfiguration")]
        public TestTouchPointConfigurationType[] TestTouchPointConfiguration
        {
            get
            {
                return this.testTouchPointConfigurationField;
            }
            set
            {
                this.testTouchPointConfigurationField = value;
            }
        }
        
        public ActionTypeCodes Action
        {
            get
            {
                return this.actionField;
            }
            set
            {
                this.actionField = value;
                this.ActionSpecified = true;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual bool ActionSpecified
        {
            get
            {
                return this.ActionFieldSpecified;
            }
            set
            {
                this.ActionFieldSpecified = value;
            }
        }
    }
}
