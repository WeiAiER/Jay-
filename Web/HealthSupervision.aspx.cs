using Class_SQL.Web;
using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Class_SQL
{
    public partial class HealthSupervision : System.Web.UI.Page
    {
        protected int totalCount;//总用户条数
        protected int page;//页数
        protected int pageSize;//每页条数
        protected string keywords = string.Empty;//查询条件

        Class_SQL.BLL.Sys_DailyHealthStatus bll_Daily = new BLL.Sys_DailyHealthStatus();
        Class_SQL.BLL.Sys_UserReister bll_User = new BLL.Sys_UserReister();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Type"].Equals("1"))
            {
                menu1.Visible = false;
                menu2.Visible = false;
                menu3.Visible = false;
                menu4.Visible = false;
                menu5.Visible = false;
            }
            if (Session["Type"].Equals("2"))
            {
                old1.Visible = false;
                old2.Visible = false;
                old3.Visible = false;
                old4.Visible = false;
                menu5.Visible = false;
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

            if (Session["admin_id"] == null)
            {
                Response.Write("<script language=javascript>window.open('Login.aspx','_parent')</script>");
            }
            this.keywords = HttpContext.Current.Request.QueryString["keywords"];//从网址上取keywords
            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                //RptBind();
                RptBind(keywords);//获取数据
            }
        }

        #region 数据绑定=================================
        private void RptBind(string strWhere)
        {
            if (strWhere == null)
            {
                strWhere = "";
            }
            this.page = MXRequest.GetQueryInt("page", 1);//获取第一页内容
            txtKeywords.Text = this.keywords;//保留查询条件值

            DataSet ds_User = bll_User.GetList("UserID = '" + Session["admin_id"] + "'");
            DataTable dt_Daily = bll_Daily.GetList("UserName = '" + ds_User.Tables[0].Rows[0]["UserName"] + "'").Tables[0];//需要转换三层架构，dtx.admins替换为dataset.table[0]

            //用Linq语句实现对部门表的模糊查询
            var result = from p in dt_Daily.AsEnumerable()
                         where p.Field<string>("UserName").Contains(strWhere) || p.Field<string>("UserTemperature").Contains(strWhere)
                         select new
                         {
                             DailyStatusID = p.Field<string>("DailyStatusID"),
                             UserName = p.Field<string>("UserName"),
                             RecordTime = p.Field<DateTime>("RecordTime"),
                             UserTemperature = p.Field<string>("UserTemperature"),
                             UserHeartRate = p.Field<string>("UserHeartRate"),
                             BloodPressure = p.Field<string>("BloodPressure"),
                             UserHealthState = p.Field<string>("UserHealthState")
                         };

            this.totalCount = result.AsQueryable().Count();//符合条件的用户总数
            //分页获取数据
            this.rptList.DataSource = result.AsQueryable().Skip((page - 1) * pageSize).Take(pageSize).ToList();
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("HealthSupervision.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion
        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("manager_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("HealthSupervision.aspx", "keywords={0}", txtKeywords.Text));//跳转页面，并携带keywords
        }

        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("manager_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("HealthSupervision.aspx", "keywords={0}", this.keywords));
        }
    }
}