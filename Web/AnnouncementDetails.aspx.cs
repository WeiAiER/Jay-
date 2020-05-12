using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Class_SQL.Web
{
    public partial class AnnouncementDetails : System.Web.UI.Page
    {
        private string action = HttpContext.Current.Request.QueryString["action"]; //操作类型
        private long id = 0;

        Class_SQL.BLL.Sys_Text bll_Text = new BLL.Sys_Text();
        Class_SQL.DAL.Sys_Text dal_Text = new Class_SQL.DAL.Sys_Text();
        Class_SQL.Model.Sys_Text model_Text = new Class_SQL.Model.Sys_Text();
        DealID deal_Text = new DealID();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Type"].Equals("1"))
            {
                menu1.Visible = false;
                menu2.Visible = false;
                menu3.Visible = false;
                menu4.Visible = false;
                menu5.Visible = false;
                btn_Save_1.Visible = false;
            }
            if (Session["Type"].Equals("2"))
            {
                old1.Visible = false;
                old2.Visible = false;
                old3.Visible = false;
                old4.Visible = false;
                menu5.Visible = false;
                btn_Save_1.Visible = false;
            }
            if (Session["Type"].Equals("3"))
            {
                menu1.Visible = false;
                menu2.Visible = false;
                menu3.Visible = false;
                menu4.Visible = false;
                old1.Visible = false;
                old2.Visible = false;
                old3.Visible = false;
                old4.Visible = false;
            }

            string _action = MXRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == "Edit")
            {
                this.action = "Edit";//修改类型
                if (!long.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    Alert.AlertAndRedirect("传输参数不正确！", "AnnouncementDetails.aspx");
                    return;
                }
                DataSet ds_Register = bll_Text.GetList("TextNumber = '" + id.ToString() + "'");

                if (ds_Register.Tables[0].Rows.Count == 0)
                {
                    Alert.AlertAndRedirect("记录不存在或已被删除！", "AnnouncementDetails.aspx");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                if (action == "Edit") //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(long _id)
        {
            //在修改时，给文本框赋值
            DataSet ds_Text = bll_Text.GetList("TextNumber = '" + _id.ToString() + "'");
            txt_Content.Text = ds_Text.Tables[0].Rows[0]["TextInfo"].ToString();
            txt_Time.Text = ds_Text.Tables[0].Rows[0]["TextTime"].ToString();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            if (Session["admin_id"] != null)//如果id不为空，进行赋值
            {
                model_Text.TextNumber = deal_Text.Deal_ID();
                model_Text.TextInfo = txt_Content.Text;
                model_Text.TextTime = Convert.ToDateTime(txt_Time.Text);
                bll_Text.Add(model_Text);
            }
            else
            {
                Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                return false;
            }
            return true;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(long id)
        {
            if (Session["admin_id"] != null)
            {
                model_Text.TextNumber = id.ToString();
                model_Text.TextInfo = txt_Content.Text;
                model_Text.TextTime = DateTime.Now;
                dal_Text.Update(model_Text);
            }
            else
            {
                Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                return false;
            }
            return true;
        }
        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (action == "Edit") //修改
            {
                if (!DoEdit(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "AnnouncementDetails.aspx");
                    return;
                }
                Alert.AlertAndRedirect("更新用户成功！", "Announcement.aspx");
            }
            else
            {
                if (!DoAdd())
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "AnnouncementDetails.aspx");
                    return;
                }
                Alert.AlertAndRedirect("添加用户成功！", "Announcement.aspx");
            }
        }

    }
}