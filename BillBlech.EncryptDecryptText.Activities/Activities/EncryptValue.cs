using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using BillBlech.EncryptDecryptText.Activities.Properties;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;

namespace BillBlech.EncryptDecryptText.Activities
{
    [LocalizedDisplayName(nameof(Resources.EncryptValue_DisplayName))]
    [LocalizedDescription(nameof(Resources.EncryptValue_Description))]
    public class EncryptValue : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.EncryptValue_PlainText_DisplayName))]
        [LocalizedDescription(nameof(Resources.EncryptValue_PlainText_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> PlainText { get; set; }

        [LocalizedDisplayName(nameof(Resources.EncryptValue_EncryptedText_DisplayName))]
        [LocalizedDescription(nameof(Resources.EncryptValue_EncryptedText_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<string> EncryptedText { get; set; }

        #endregion


        #region Constructors

        public EncryptValue()
        {
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (PlainText == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(PlainText)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Inputs
            var plainText = PlainText.Get(context);

            ///////////////////////////
            // Add execution logic HERE
            string password = "BillBlech";
            //Encrypt Text
            string encryptedText = Cipher.Encrypt(plainText, password);
            ///////////////////////////

            // Outputs
            return (ctx) => {
                EncryptedText.Set(ctx, encryptedText);
            };
        }

        #endregion
    }
}

