using System.Activities.Presentation.Metadata;
using System.ComponentModel;
using System.ComponentModel.Design;
using BillBlech.EncryptDecryptText.Activities.Design.Designers;
using BillBlech.EncryptDecryptText.Activities.Design.Properties;

namespace BillBlech.EncryptDecryptText.Activities.Design
{
    public class DesignerMetadata : IRegisterMetadata
    {
        public void Register()
        {
            var builder = new AttributeTableBuilder();
            builder.ValidateTable();

            var categoryAttribute = new CategoryAttribute($"{Resources.Category}");

            builder.AddCustomAttributes(typeof(EncryptValue), categoryAttribute);
            builder.AddCustomAttributes(typeof(EncryptValue), new DesignerAttribute(typeof(EncryptValueDesigner)));
            builder.AddCustomAttributes(typeof(EncryptValue), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(DecryptValue), categoryAttribute);
            builder.AddCustomAttributes(typeof(DecryptValue), new DesignerAttribute(typeof(DecryptValueDesigner)));
            builder.AddCustomAttributes(typeof(DecryptValue), new HelpKeywordAttribute(""));


            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}
