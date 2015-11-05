using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Security.Policy;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace MostActiveFriend
{
    
    public partial class Form1 : Form
    {
        private string _accessToken;
        private int _userId;
        private int _max;
        private long _mostActiveFriendId;
        Form _answer;
        private int _appId;

        public Form1()
        {
           
            InitializeComponent();
            _accessToken = "";
            _appId = 5086307;
            webBrowser1.Navigate(String.Format("http://api.vkontakte.ru/oauth/authorize?client_id={0}&display=popup&redirect_uri=https://oauth.vk.com/blank.html&scope=friends&response_type=token", _appId.ToString()));
            _max = 0;
        }

        private  void button1_Click(object sender, EventArgs e)
        {
           
            FriendList friendList = MyParseJSON.ParseFriendList(VkChaterer.GetFriends(_userId));
            //находим самого активного друга по постам           
            foreach (FriendResponse response in friendList.response)
            {
                FriendWall friendWall = MyParseJSON.ParseFriendWall(VkChaterer.GetPosts(response.user_id));
                friendWall.user_id = response.user_id;
               if (_max < friendWall.count)
                {
                    _max = friendWall.count;
                    _mostActiveFriendId = friendWall.user_id;
                }

            }
            _answer = new Form2(_mostActiveFriendId, _max);
            _answer.Show();

        }
       
       private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.ToString().IndexOf("access_token", StringComparison.Ordinal) != -1)
            {
                
                
                Regex myReg = new Regex(@"(?<name>[\w\d\x5f]+)=(?<value>[^\x26\s]+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                foreach (Match m in myReg.Matches(e.Url.ToString()))
                {
                    if (m.Groups["name"].Value == "access_token")
                    {
                        _accessToken = m.Groups["value"].Value;
                    }
                    else if (m.Groups["name"].Value == "user_id")
                    {
                        _userId = Convert.ToInt32(m.Groups["value"].Value);
                    }
                    // еще можно запомнить срок жизни access_token - expires_in,
                    // если нужно
                }
                button1.Visible = true;
              //  System.Windows.Forms.MessageBox.Show(String.Format("Ключ доступа: {0}\nUserID: {1}", _accessToken, _userId));
            }
        }
        
   
   }
   
  

}
