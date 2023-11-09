using Microsoft.AspNetCore.Mvc;
using WebApplication3;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class CRUDController : Controller //클라이언트에서 crud 요청이 들어오면 여기서 실행하고 뷰에서 보는겨
    {
        List<CultureAssets> list;
        Csharp_ca cual;
        public CRUDController()
        {
            String connString = /*sql접속문*/
            cual = new Csharp_ca(connString);//접속 문자열을 임마한테 넘겨준다 
        }
        public IActionResult Index()//모든데이터를 보고싶을때 다출력 시키는 자식 getstudent를 사용
        {
            list = cual.GetCa();// 함수에서 가져온 리턴값을 리스트에 넘겨준다
            return View(list);//함수에서 넘어온 리턴값을 html페이지로 전달해라
        }
        public IActionResult Create()
        {
            return View();
        }
        public ActionResult Find(string no)
        {

            var std = cual.SelectCa(no);
            return View(std);


        }

        [HttpPost]
        public ActionResult Findpost(IFormCollection form)
        {
            var no = form["ca_name"].ToString();
            var result = cual.SelectCa(no);

            return View(result);

        }
        /*public ActionResult Createpost(IFormCollection form)
        {
            var type = form["ca_type"].ToString();
            var name = form["ca_name"].ToString();
            var addr = form["ca_addr"].ToString();
            var period = form["ca_name"].ToString();
            var date = Convert.ToDateTime(form["ca_date"]);
            var ditail = form["ca_ditail"].ToString();
            int result = cual.InsertCa(type,name,addr,period,date,ditail);
            TempData["result"] = result;
            return View();
           
        }*/
        /*
        public ActionResult Update(int id)//선택된 데이터 보냄
        {//액션링크>>누르면 컨트롤러로 데이터가 들어옴 
            var std = stud.SelectStudent(id);
            return View(std);
        }
        [HttpPost]
        public ActionResult Updatepost(IFormCollection form)
        {
            var studentid = Convert.ToInt32(form["StudentId"]);
            var studentname = form["Studentname"].ToString();
            var age = Convert.ToInt32(form["Age"]);
            int result = stud.UpdateStudent(studentid, studentname, age); //리져트를 받아서
            TempData["result"] = result; //템프 데이터로넘겨줌
            return View();
        }
        public ActionResult Details(int id)
        {
            var std = stud.SelectStudent(id);
            return View(std);
        }
        public ActionResult Delete(int id)
        {
            var std = stud.SelectStudent(id);
            return View(std);
        }
        public ActionResult Deletepost(int id)//확인후 제거하기 위해 만듬
        {
            int result = stud.DeleteStudent(id);
            TempData["result"] = result;
            return View();
        }
        //dept_emp에 대하여 CRUD하는 웹페이지를 작성해 보세요(팀으로 작업)
        public ActionResult Storedprocedurecall(int id)
        {
            var std = stud.Storedprocedurecall(id); //매개변수로 넘어온 아이디를 가지고
            return View(std);//뷰로 넘겨준다 
        }
        public ActionResult sp_delete(int id)
        {
            int result = stud.sp_delete(id); //매개변수로 넘어온 아이디를 가지고
            return RedirectToAction("Index");
        }*/
    }
}
