namespace Retalix.Jumbo.Contracts.Generated.TestTouchPointKR
{
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BatchContractGenerator.Console", "14.100.999")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://retalix.com/R10/services")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://retalix.com/R10/services", IsNullable=true)]
    public partial class SearchCriteriaType
    {
        
        private string businessUnitIdField;
        
        private string entityTypeField;
        
        private string entityParameterField;
        
        public string BusinessUnitId
        {
            get
            {
                return this.businessUnitIdField;
            }
            set
            {
                this.businessUnitIdField = value;
            }
        }
        
        public string EntityType
        {
            get
            {
                return this.entityTypeField;
            }
            set
            {
                this.entityTypeField = value;
            }
        }
        
        public string EntityParameter
        {
            get
            {
                return this.entityParameterField;
            }
            set
            {
                this.entityParameterField = value;
            }
        }
    }
}
