using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectMarket.Shared
{
    public static class ContentNames
    {
        public const string CONNECT_BANNER_MESSAGE = "CONNECT_BANNER_MESSAGE";
    }

    public static class ModalNames
    {
        public const string PROFILE_MODAL = "profile-modal";
        public const string LOADING_SPINNER = "loading-spinner";
    }

    public static class ApplicationStorageKeys
    {
        public const string GLOBAL_PRODUCERS = "global-producers";
        public const string ACTIVE_GLOBAL_PRODUCER_ID = "active-global-producer";
        public const string SELECTED_SITE_ID = "selected-site";
        public const string SELECTED_DATE = "selected-date";
        public const string BANNER_MESSAGE = ContentNames.CONNECT_BANNER_MESSAGE;
        public const string PRODUCER_MESSAGES = "producer-messages";
    }

    public static class HttpClientName
    {
        public const string INTEGRATE = "Integrate";
        public const string CONNECT = "Connect";
        public const string UNAUTHORIZED = "Unauthorized ";
        public const string GROW_API = "GrowApi";
    }

    public static class ConfigurationKeys
    {
        public const string LFM_INTEGRATION_URL = "LfmIntegration:Url";
        public const string CONNECT_MARKET_URL = "ConnectMarketUrl";
    }
}
