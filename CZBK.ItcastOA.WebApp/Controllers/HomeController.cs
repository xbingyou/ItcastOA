using CZBK.ItcastOA.Model;
using CZBK.ItcastOA.Model.ChartModel;
using CZBK.ItcastOA.Model.EnumType;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CZBK.ItcastOA.WebApp.Controllers
{
    public class HomeController : BaseController
    {
        IBLL.IUserinfoService UserInfoService { get; set; }
        // GET: Home
        public ActionResult Index()//WebQQ布局
        {
            ViewData["name"]= LoginUser.UNAME;
            return View();
        }
        public ActionResult HomePage()//传统布局
        {
            ViewData["name"] = LoginUser.UNAME;
            return View();
        }
        public ActionResult HomeMainPage()//菜单可缩小布局
        {
            ViewData["name"] = LoginUser.UNAME;
            return View();
        }
        public ActionResult PublicPage()//首页
        {
            return View();
        }
        public JsonResult GetEchartsRentalReturn()
        {
            //考虑到图表的category是字符串数组 这里定义一个string的List
            List<string> categoryList = new List<string>();
            //考虑到图表的series数据为一个对象数组 这里额外定义一个series的类
            List<Series> seriesList = new List<Series>();
            //考虑到Echarts图表需要设置legend内的data数组为series的name集合这里需要定义一个legend数组
            List<string> legendList = new List<string>();
            legendList.Add("Rental"); //这里的名称必须和series的每一组series的name保持一致
            legendList.Add("Return"); 

            Series rentalSeries = new Series();
            rentalSeries.id = 0;
            rentalSeries.name = "Rental";
            rentalSeries.type = "line"; //线性图呈现
            rentalSeries.data = new List<object>();
            rentalSeries.itemStyle = new itemStyle { normal = new normal { color = "#0099FF" } };

            Series returnSeries = new Series();
            returnSeries.id = 1;
            returnSeries.name = "Return";
            returnSeries.type = "line"; //线性图呈现
            returnSeries.data = new List<object>();
            returnSeries.itemStyle = new itemStyle { normal = new normal { color = "#00CC00" } };
            Random rd = new Random();
            for (int i = 6; i <= 23; i++)
            {
                categoryList.Add(i.ToString());
                rentalSeries.data.Add(rd.Next(0, 801));
                returnSeries.data.Add(rd.Next(0, 801));
            }

            //将sereis对象压入sereis数组列表内
            seriesList.Add(rentalSeries);
            seriesList.Add(returnSeries);
            var newObj = new
            {
                category = categoryList,
                series = seriesList,
                legend = legendList
            };

            return Json(newObj, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEchartsStation()
        {
            List<string> categoryList = new List<string>();
            List<Series> seriesList = new List<Series>();

            Series stationSeries = new Series();
            stationSeries.id = 0;
            stationSeries.name = "Site";
            stationSeries.type = "bar";
            stationSeries.data = new List<object>();
            stationSeries.itemStyle = new itemStyle { normal = new normal { color = "#00CC00" } };

            Random re = new Random();
            for (int i = 1001; i <= 1042; i++)
            {
                categoryList.Add(i.ToString());
                stationSeries.data.Add(re.Next(0, 101));                
            }
            seriesList.Add(stationSeries);
            var newObj = new
            {
                category = categoryList,
                series = seriesList
            };
            return Json(newObj, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEchartsStationStats()
        {
            List<string> categoryList = new List<string>();
            List<object> seriesDataList = new List<object>();
            SortedList htStats = new SortedList();
            string name = "<br/>De Park<br/>15/30=50%<br/>-N-L";
            Random re = new Random();
            for (int i = 1001; i <= 1035; i++)
            {
                categoryList.Add(i.ToString());
                //seriesDataList.Add(re.Next(0, 101));
                htStats.Add(i.ToString()+name , re.Next(0, 101));
            }
            var newObj = new
            {
                category = categoryList,
                //data = seriesDataList,
                hash = htStats
            };
            return Json(newObj, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEchartsSiteStatus()
        {
            List<Series> seriesList = new List<Series>();

            Series stationSeries = new Series();
            stationSeries.data = new List<object>();

            Random re = new Random();
            int a = re.Next(0,10);
            data dt = new data();
            dt.itemStyle = new itemStyle { normal = new normal { color = "#EABA0F" } };
            dt.name = "High : "+a.ToString();
            dt.value = a;

            a = re.Next(0, 10);
            data dt1 = new data();
            dt1.itemStyle = new itemStyle { normal = new normal { color = "#2196F3" } };
            dt1.name = "Normal : " + a.ToString();
            dt1.value = a;

            a = re.Next(0, 30);
            data dt2 = new data();
            dt2.itemStyle = new itemStyle { normal = new normal { color = "#512DA8" } };
            dt2.name = "Low : " + a.ToString();
            dt2.value = a;

            a = re.Next(0, 30);
            data dt3 = new data();
            dt3.itemStyle = new itemStyle { normal = new normal { color = "#C53725" } };
            dt3.name = "Fault : " + a.ToString();
            dt3.value = a;

            stationSeries.data.Add(dt);
            stationSeries.data.Add(dt1);
            stationSeries.data.Add(dt2);
            stationSeries.data.Add(dt3);
            seriesList.Add(stationSeries);
            var newObj = new
            {
                series = seriesList
            };
            return Json(newObj, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 1: 可以按照用户---角色---权限这条线找出登录用户的权限，放在一个集合中。
        /// 2：可以按照用户---权限这条线找出用户的权限，放在一个集合中。
        /// 3：将这两个集合合并成一个集合。
        /// 4：把禁止的权限从总的集合中清除。
        /// 5：将总的集合中的重复权限清除。
        /// 6：把过滤好的菜单权限生成JSON返回。
        /// </summary>
        /// <returns></returns>
        public ActionResult Getmenus()
        {
            // 1: 可以按照用户---角色---权限这条线找出登录用户的权限，放在一个集合中。
            //获取登陆用户的信息
            var userInfo = UserInfoService.LoadEntities(u => u.ID == LoginUser.ID).FirstOrDefault();
            //获取登陆用户的角色
            var userRoleInfo = userInfo.R_USERINFO_ROLEINFO;
            //根据登陆用户的角色获取对应的菜单权限
            short actionTypeEnum = (short)ActionTypeEnum.MenuActionType;
            var roleActions = from r in userRoleInfo
                              from a in r.ROLEINFO.R_ROLEINFO_ACTIONINFO
                              select a.ACTIONINFO;
            var loginUserMenuActions = (from a in roleActions
                                        where a.ACTIONTYPEENUM == actionTypeEnum
                                        select a).ToList();

            //下面语句是错误的，allUserActions是一个大集合该集合中包含了很多小的集合，所以变量b为集合类型
            //var allUserActions = from r in userRoleInfo
            //                     select r.ActionInfo;
            //var mm = from b in allUserActions
            //         where b.ActionTypeEnum == actionTypeEnum
            //         select b;


            // 2：可以按照用户---权限这条线找出用户的权限，放在一个集合中。
            var userActions = from a in userInfo.R_USERINFO_ACTIONINFO
                              select a.ACTIONINFO;
            var userMenuActions = (from a in userActions
                                   where a.ACTIONTYPEENUM == actionTypeEnum
                                   select a).ToList();

            // a.ActionInfo不是一个集合,注意理解权限表与用户权限关系表之间的对应关系
            //var userMenuActionse = from a in userInfo.R_UserInfo_ActionInfo
            //                       from b in a.ActionInfo
            //                       where b.ActionTypeEnum == actionTypeEnum
            //                       select b;



            //3：将这两个集合合并成一个集合。
            loginUserMenuActions.AddRange(userMenuActions);

            //4：把禁止的权限从总的集合中清除。
            var forbidActions = (from a in userInfo.R_USERINFO_ACTIONINFO
                                 where a.ISPASS == 0
                                 select a.ACTIONINFOID).ToList();
            var loginUserAllowActions = loginUserMenuActions.Where(a => !forbidActions.Contains(a.ID));

            //5：将总的集合中的重复权限清除。
            var lastLoginUserActions = loginUserAllowActions.Distinct(new EqualityComparer());
            //6：把过滤好的菜单权限生成JSON返回。
            var temp = from a in lastLoginUserActions
                       select new { icon = a.MENUICON, title = a.ACTIONINFONAME, url = a.URL };
            return Json(temp, JsonRequestBehavior.AllowGet);
        }
    }
}