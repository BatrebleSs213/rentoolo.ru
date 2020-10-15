﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Rentoolo.Model;

namespace Rentoolo.Account
{
    public partial class UserProfile : BasicPage
    {
        // не менять имя, при изменении имени на User будет конфликт имен при наследовании
        public Users CurUser;
        public List<Chats> ChatList;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            CurUser = DataHelper.GetUser(Guid.Parse(Request.QueryString["id"]));
            ChatList = DataHelper.GetChats(User.UserId);

            RptrComments.DataSource = ChatList;
            RptrComments.DataBind();
            


            if (!IsPostBack)
            {
                
                
            }
        }

        // join to chat
        protected void Button1_Click(object sender, EventArgs e)
        {
            DataHelper.CreateChatDialog(new Chats() {
                OwnerId = User.UserId, ChatType = 1, ChatName = CurUser.UserName
            }, CurUser.UserId);
        }

        protected void ChatList_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }


        protected void RptrChats_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void RptrChats_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string cmdName = e.CommandName.ToString();
            string cmdArg = e.CommandArgument.ToString();


            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void RptrComments_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void RptrComments_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string cmdName = e.CommandName.ToString();
            string cmdArg = e.CommandArgument.ToString();
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {

            Chats chat = ChatList.FirstOrDefault(x => x.ChatName == TextBox1.Text);
            DataHelper.AddChatUser(new ChatUsers() { ChatId = chat.Id, UserId = CurUser.UserId });
        }
    }
}