namespace Hotel.WebUI.Dtos.DashboardFollowersDto
{
    public class TwitterFollowersDto
    {
       
       
            public Data data { get; set; }
       

        public class Data
        {
            public User user { get; set; }
        }

        public class User
        {
            public Result result { get; set; }
        }

        public class Result
        {
            public string __typename { get; set; }
            public string id { get; set; }
            public string rest_id { get; set; }
            public Affiliates_Highlighted_Label affiliates_highlighted_label { get; set; }
            public bool has_graduated_access { get; set; }
            public bool is_blue_verified { get; set; }
            public string profile_image_shape { get; set; }
            public Legacy legacy { get; set; }
            public bool smart_blocked_by { get; set; }
            public bool smart_blocking { get; set; }
            public Legacy_Extended_Profile legacy_extended_profile { get; set; }
            public bool has_hidden_likes_on_profile { get; set; }
            public Verification_Info verification_info { get; set; }
            public Highlights_Info highlights_info { get; set; }
            public Business_Account business_account { get; set; }
            public int creator_subscriptions_count { get; set; }
        }

        public class Affiliates_Highlighted_Label
        {
        }

        public class Legacy
        {
            public bool can_dm { get; set; }
            public bool can_media_tag { get; set; }
            public string created_at { get; set; }
            public bool default_profile { get; set; }
            public bool default_profile_image { get; set; }
            public string description { get; set; }
            public Entities entities { get; set; }
            public int fast_followers_count { get; set; }
            public int favourites_count { get; set; }
            public int followers_count { get; set; }
            public int friends_count { get; set; }
            public bool has_custom_timelines { get; set; }
            public bool is_translator { get; set; }
            public int listed_count { get; set; }
            public string location { get; set; }
            public int media_count { get; set; }
            public string name { get; set; }
            public int normal_followers_count { get; set; }
            public string[] pinned_tweet_ids_str { get; set; }
            public bool possibly_sensitive { get; set; }
            public string profile_banner_url { get; set; }
            public string profile_image_url_https { get; set; }
            public string profile_interstitial_type { get; set; }
            public string screen_name { get; set; }
            public int statuses_count { get; set; }
            public string translator_type { get; set; }
            public bool verified { get; set; }
            public bool want_retweets { get; set; }
            public object[] withheld_in_countries { get; set; }
        }

        public class Entities
        {
            public Description description { get; set; }
        }

        public class Description
        {
            public object[] urls { get; set; }
        }

        public class Legacy_Extended_Profile
        {
        }

        public class Verification_Info
        {
        }

        public class Highlights_Info
        {
            public bool can_highlight_tweets { get; set; }
            public string highlighted_tweets { get; set; }
        }

        public class Business_Account
        {
        }


    }
}
