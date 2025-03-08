// *********************************************************************************
//	<copyright file="LoggingConstants.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>Logging constants.</summary>
// *********************************************************************************

namespace IBBS.AI.Shared.Constants
{
    /// <summary>
    /// Logging constants.
    /// </summary>
    public static class LoggingConstants
    {
        #region Logging

        /// <summary>
        /// The log helper method start.
        /// </summary>
        public const string LogHelperMethodStart = "{0} started at {1}";

        /// <summary>
        /// The log helper method failed.
        /// </summary>
        public const string LogHelperMethodFailed = "{0} failed at {1} with {2}";

        /// <summary>
        /// The log helper method end.
        /// </summary>
        public const string LogHelperMethodEnd = "{0} ended at {1}";

        #endregion

        #region Exceptions

        /// <summary>
        /// The story cannot be empty message.
        /// </summary>
        public const string StoryCannotBeEmptyMessage = "The entered story/string is empty!";

        /// <summary>
        /// The ai services down message.
        /// </summary>
        public const string AiServicesDownMessage = "We are facing technical issues with our AI services. Please try again after sometime.";

        /// <summary>
        /// The plugin not found message.
        /// </summary>
        public const string PluginNotFoundMessage = "Plugin not found!";

        /// <summary>
        /// The ai api key missing message.
        /// </summary>
        public const string AiAPIKeyMissingMessage = "The AI Api Key is missing in configuration.";

        /// <summary>
        /// The missing configuration message.
        /// </summary>
        public const string MissingConfigurationMessage = "The Configuration Key is missing";

        /// <summary>
        /// The user unauthorized message constant
        /// </summary>
        public const string UserUnauthorizedMessageConstant = "User Not Authorized";

        /// <summary>
        /// The ai services down message constant.
        /// </summary>
        public const string AiServicesDownMessageConstant = "Our AI Services are down right now. Please try again after sometime.";

        #endregion
    }
}