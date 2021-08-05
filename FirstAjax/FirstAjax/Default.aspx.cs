﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstAjax
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                Label1.Text = Label2.Text = "目前時間" + DateTime.Now.ToString();
            }
        }

        private void InitializeComponent()
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = "同步更新目前時間" + DateTime.Now.ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label2.Text = "非同步跟新目前時間" + DateTime.Now.ToString();
        }
    }
}