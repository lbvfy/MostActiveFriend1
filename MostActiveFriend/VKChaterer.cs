using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace MostActiveFriend
{
     public class VkChaterer
    {
        public string GetToken(int idApp)
        {
           
            return "0";
        }

        public static string GetUser(int userId)
        {
            return Get(String.Format("https://api.vk.com/method/users.get?user_ids={0}", userId));
        }

        public int GetPostsCount(int idOwnerWall)
        {
            return 0;
        }

        public static string GetFriends(int userId)
        {
            return Get(String.Format("https://api.vk.com/method/friends.get?user_id={0}&order=hints&fields=can_see_all_posts",userId.ToString()));//получаем друзе
           
        }

        public static string Get(string url)
        {
            string Out;
            WebRequest req = WebRequest.Create(url);
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            using (StreamReader sr = new StreamReader(stream))
            {
                Out = new string(sr.ReadToEnd().ToCharArray());
            }
            // sr.Close();
           // MessageBox.Show(Out);
            return Out;
        }
    }
}
