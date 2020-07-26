using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using BillBlech.EncryptDecryptText.Activities.Properties;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;

namespace BillBlech.EncryptDecryptText.Activities
{
    [LocalizedDisplayName(nameof(Resources.DecryptValue_DisplayName))]
    [LocalizedDescription(nameof(Resources.DecryptValue_Description))]
    public class DecryptValue : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.DecryptValue_EncryptedText_DisplayName))]
        [LocalizedDescription(nameof(Resources.DecryptValue_EncryptedText_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> EncryptedText { get; set; }

        [LocalizedDisplayName(nameof(Resources.DecryptValue_PlainText_DisplayName))]
        [LocalizedDescription(nameof(Resources.DecryptValue_PlainText_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<string> PlainText { get; set; }

        #endregion


        #region Constructors

        public DecryptValue()
        {
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (EncryptedText == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(EncryptedText)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Inputs
            var encryptedText = EncryptedText.Get(context);

            ///////////////////////////
            // Add execution logic HERE

            string password = "BillBlech";
            string plainText = Cipher.Decrypt(encryptedText, password);
            ///////////////////////////

            // Outputs
            return (ctx) => {
                PlainText.Set(ctx, plainText);
            };
        }

        #endregion
    }
}

