using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace UploadingProduct
{
    public partial class Form1 : Form
    {

        private string filePath = "";
        private dynamic jsonData;
        private string imgFilePath = "";
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {




            //System.Net.HttpWebRequest webreq = ((System.Net.HttpWebRequest)(System.Net.WebRequest.Create("https://www.sixshop.com/dashboard/shop-products")));
            //System.Net.CookieContainer cookies = new System.Net.CookieContainer();



            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileNameBox.Clear();
                fileNameBox.Text = openFileDialog.FileName;
                filePath = openFileDialog.FileName;



                var lines = System.IO.File.ReadAllLines(filePath, Encoding.GetEncoding(949));
                // var lines = System.IO.File.ReadAllLines(filePath);

                var csv = lines.Select(l => l.Split(',')).ToList();

                var headers = csv[0];
                var dicts = csv.Skip(1).Select(row => Enumerable.Zip(headers, row, Tuple.Create).ToDictionary(p => p.Item1, p => p.Item2)).ToArray();

                string json = new JavaScriptSerializer().Serialize(dicts);
                jsonData = JsonConvert.DeserializeObject<dynamic>(json);

                //리스트 뽑아내기
                setColum();
                addData();




            }


        }
        private void setColum()
        {
            dataGridView.ColumnCount = 2;
            dataGridView.Columns[0].Name = "상품명";
            dataGridView.Columns[1].Name = "완료여부";
        }
        private void addData()
        {

            foreach (var item in jsonData)
            {
                dataGridView.Rows.Add(new string[2] { item.이름, "" });
            }
        }
        private void sendData()
        {

            //쿠키 가지고 오기

            //포스트 날리기
            string URI = "https://www.sixshop.com/_shop/updateShopProduct";
            //string URI = "https://www.sixshop.com/dashboard/shop-products";
            string myParameters = "{\"memberNo\":\"158883\",\"productName\":\"소프트 실리콘 주걱\",\"naverProductName\":\"\",\"productPrice\":\"15000\",\"productDiscountPrice\":\"10000\",\"productImgs\":\"{\"src\":\" / uploadedFiles / 18850 / product / image_1490944166959.png\"},{\"src\":\" / uploadedFiles / 18850 / product / image_1490944168610.png\"}\",\"productThumbnail\":\"/uploadedFiles/18850/product/image_1490944166959.png\",\"productQuantity\":\"-1\",\"productSKU\":\"\",\"productBrand\":\"\",\"productMaker\":\"\",\"productOrigin\":\"\",\"productOptionsInfo\":\"\",\"productOptionVariations\":\"\",\"productAddress\":\"21\",\"productOptionImageSequenceArray\":\"\",\"productAdditionalOptions\":[],\"productCaption\":\"청춘의 살았으며, 사라지지 고행을 기관과 것이다. 얼음에 따뜻한 있음으로써 길지 말이다. 그들에게 아니더면, 보배를 약동하다. 가슴이 뜨고, 뜨거운지라, 방황하였으며, 인간의 교향악이다. 동산에는 타오르고 이 뭇 이것이야말로 것이다. 보라, 봄날의 못할 보라. 따뜻한 이것을 위하여, 보내는 생생하며, 끝에 같이, 작고 꽃이 사막이다.\",\"productSummaryHeaderNo\":\"0\",\"productSummaryFooterNo\":\"0\",\"productDescription\":\"\",\"sellStatus\":\"selling\",\"nowSection\":\"editProduct\",\"productNo\":2033700,\"productOptions\":\"{\"badgeType\":\"default\",\"useRelatedProduct\":\"notUseRelatedProduct\",\"useNaverPay\":\"use\",\"useAlternativeMsgOnPricing\":\"notUseAlternativeMsgOnPricing\"}\",\"taxFree\":\"no\",\"importProduct\":\"\",\"productFlag\":null,\"productCondition\":null,\"naverEventWords\":\"\",\"productType\":\"\",\"productCommonHeaderNo\":\"0\",\"productCommonFooterNo\":\"0\",\"useNaverShoppingSetting\":\"notUseNaverShoppingSetting\",\"categoryList\":[\"361571\"],\"productMetaKeywords\":\"\",\"productAlternativeMsgCustomerGrades\":[{\"customerGradeNo\":\"-1\",\"productAlternativeMsg\":\"\"},{\"customerGradeNo\":\"-2\",\"productAlternativeMsg\":\"\"}],\"relatedProductList\":[],\"useRelatedProduct\":\"notUseRelatedProduct\",\"salesStartTime\":null,\"salesEndTime\":null,\"shippingPolicyId\":216697}";
            //string myParameters = "\"memberNo\":\"158883\"";
            byte[] utf8Bytes = Encoding.GetEncoding("UTF-8").GetBytes(myParameters);
            string parameters = Encoding.GetEncoding("UTF-8").GetString(utf8Bytes);



            HttpWebRequest wc = (HttpWebRequest)WebRequest.Create(URI);
            wc.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            wc.Method = "POST";


            //wc.Headers.Add("Accept", "application/json, text/javascript, */*; q=0.01");
            //wc.Headers.Add("X-Requested-With", "XMLHttpRequest");
            //wc.Headers.Add("member-id", "158883");
            //wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.190 Safari/537.36");
            //wc.Headers.Add("memberNo", "158883");
            //wc.Headers.Add("Content-Type", "application/json");
            //wc.Headers.Add("Sec-Fetch-Site", "same-origin");
            //wc.Headers.Add("Sec-Fetch-Mode", "cors");
            //wc.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            //wc.Headers.Add("Accept-Language", "ko-KR,ko;q=0.9,en-US;q=0.8,en;q=0.7");
            //wc.Headers.Add("Cookie", "SESSION=N2QwMzJhOWUtOTZlNi00YzZhLWFjZmQtMmNlZGFhZTU1OTM2; NA_SA=Y2k9MEFhMDAwMVZCaFh1X0cxLTUxMVN8dD0xNjE0NzgxODI0fHU9aHR0cHMlM0ElMkYlMkZ3d3cuc2l4c2hvcC5jb20lMkYlM0ZOYVBtJTNEY3QlMjUzRGtsdGplaHJzJTI1N0NjaSUyNTNEMEFhMDAwMVZCaFh1JTI1NUZHMSUyNTJENTExUyUyNTdDdHIlMjUzRGJybmQlMjU3Q2hrJTI1M0Q4YTQyZDU5OWYxY2NiMjk4ZDQwNWUyY2NlZDdlNzQ2NDBhZmVmMjhk; NVADID=0Aa0001VBhXu_G1-511S; NA_CO=ct%3Dkltjehrs%7Cci%3D0Aa0001VBhXu_G1-511S%7Ctr%3Dbrnd%7Chk%3D8a42d599f1ccb298d405e2cced7e74640afef28d%7Ctrx%3Dundefined; ch-veil-id=935c0a6b-fddc-4cdc-ac35-f21189846a72; KLCheck=MTU4ODgzLXd3dy5zaXhzaG9wLmNvbTIwMjEtMDMtMDNUMjM6NDE6MjkuMDk5; wcs_bt=s_1169f47cfea9:1614782756;");

            ServicePointManager.SecurityProtocol =
            SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            WebHeaderCollection header = new WebHeaderCollection()
            {
                //{"Accept", "application/json, text/javascript, */*; q=0.01" },
                {"X-Requested-With", "XMLHttpRequest" },
                {"member-id", "158883"},
                //{"User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.190 Safari/537.36" },
                {"memberNo", "158883" },
                //{ "Content-Type", "application/json"},
                { "Sec-Fetch-Site", "same-origin"},
                { "Sec-Fetch-Mode", "cors"},
                { "Accept-Encoding", "gzip, deflate, br"},
                { "Accept-Language", "ko-KR,ko;q=0.9,en-US;q=0.8,en;q=0.7"},
                {"Cookie", "SESSION=N2QwMzJhOWUtOTZlNi00YzZhLWFjZmQtMmNlZGFhZTU1OTM2; NA_SA=Y2k9MEFhMDAwMVZCaFh1X0cxLTUxMVN8dD0xNjE0NzgxODI0fHU9aHR0cHMlM0ElMkYlMkZ3d3cuc2l4c2hvcC5jb20lMkYlM0ZOYVBtJTNEY3QlMjUzRGtsdGplaHJzJTI1N0NjaSUyNTNEMEFhMDAwMVZCaFh1JTI1NUZHMSUyNTJENTExUyUyNTdDdHIlMjUzRGJybmQlMjU3Q2hrJTI1M0Q4YTQyZDU5OWYxY2NiMjk4ZDQwNWUyY2NlZDdlNzQ2NDBhZmVmMjhk; NVADID=0Aa0001VBhXu_G1-511S; NA_CO=ct%3Dkltjehrs%7Cci%3D0Aa0001VBhXu_G1-511S%7Ctr%3Dbrnd%7Chk%3D8a42d599f1ccb298d405e2cced7e74640afef28d%7Ctrx%3Dundefined; ch-veil-id=935c0a6b-fddc-4cdc-ac35-f21189846a72; KLCheck=MTU4ODgzLXd3dy5zaXhzaG9wLmNvbTIwMjEtMDMtMDNUMjM6NDE6MjkuMDk5; wcs_bt=s_1169f47cfea9:1614782756;" }

            };
            wc.ContentType = "application/json";
            wc.Accept = "application/json, text/javascript, */*; q=0.01";
            wc.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.190 Safari/537.36";
            wc.Headers = header;
            wc.ContentLength = utf8Bytes.Length;
            Stream requestStream = wc.GetRequestStream();
            requestStream.Write(utf8Bytes, 0, utf8Bytes.Length);
            requestStream.Flush();
            requestStream.Close();
            HttpWebResponse httpWebResponse = (HttpWebResponse)wc.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
            string returndata = streamReader.ReadToEnd();
            streamReader.Close();
            httpWebResponse.Close();



            //string HtmlResult = wc.UploadString(URI, "POST", parameters);

            //체크하기

        }

        private void sendDataWithWeb()
        {
            string url = "https://www.sixshop.com/dashboard/shop-products?searchKeywords=productStatus%3Dselling";
            string productListUrl = "https://www.sixshop.com/dashboard/shop-products";
            IWebDriver chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl(url);
            //로그인
            try
            {
                chrome.FindElement(By.Name("idOrUserName")).SendKeys(tbId.Text);
                chrome.FindElement(By.Name("password")).SendKeys(tbPw.Text);
                chrome.FindElement(By.XPath("//button[@class='login_submit btn btn-big btn-purple']")).Click();

            }
            catch (Exception e)
            {
                MessageBox.Show("아이디와 비번 다시 확인!! \n" + e);
                chrome.Close();
            }

            Thread.Sleep(2000);
            chrome.Navigate().GoToUrl(productListUrl);

            for (int i = 0; i < jsonData.Count; i++)
            {
                var item = jsonData[i];
                chrome.FindElement(By.XPath("//button[@id='btn_addShopProduct']")).Click();

                //상품 추가
                //이름    
                chrome.FindElement(By.XPath("//input[@id='shopProductName']")).SendKeys(item.이름.ToString());
                //상품코드
                //chrome.FindElement(By.XPath("//input[@id='shopProductSKU']")).SendKeys(item.상품코드.ToString());
                //정가
                chrome.FindElement(By.XPath("//input[@id='shopProductPrice']")).SendKeys(item.정가.ToString());
                //할인가
                //chrome.FindElement(By.XPath("//input[@id='shopProductDiscountPrice']")).SendKeys(item.할인가.ToString());
                //대표이미지
                var images = item.대표이미지.ToString().Split('|');

                foreach (var image in images)
                {
                    try
                    {
                        if (string.IsNullOrEmpty(imgFilePath))
                        {
                            chrome.FindElement(By.Id("productImageUploader")).SendKeys($"{image.Replace("\"", "").Replace(" ", "%20")}");
                        }
                        else
                        {
                            chrome.FindElement(By.Id("productImageUploader")).SendKeys($"{imgFilePath}\\{image.Replace("\"", "").Replace(" ", "%20")}");

                        }
                    }
                    catch
                    {
                        continue;
                    }
                }


                //옵션
                if (!string.IsNullOrEmpty(item.옵션.ToString()))
                {


                    chrome.FindElement(By.XPath("//button[@id='setProductOption']")).Click();
                    if (chrome.PageSource.Contains("dialog__content remove-feature-dialog-rule"))
                    {
                        string[] optionInfo = item.옵션.ToString().Replace("\"", "").Split(':');
                        chrome.FindElement(By.XPath("//input[@class='input_addOption optionName optionNameList']")).SendKeys(optionInfo[0]);
                        chrome.FindElement(By.XPath("//input[@class='optionValueInput']")).SendKeys(optionInfo[1].Replace("|", ","));
                        try
                        {
                            chrome.FindElement(By.XPath("//button[@id='btn_saveProductOptions']")).Click();
                            chrome.FindElement(By.XPath("//button[@id='btn_saveProductOptions']")).Click();

                        }
                        catch 
                        {
                        
                        }

                    }
                }
                //카테고리
                var cateList = item.카테고리.ToString().Replace("\"", "").Split('|');
                foreach (var cat in cateList)
                {
                    chrome.FindElements(By.XPath("//div[@class='checkbox']"))[int.Parse(cat)].Click();
                }
                //요약설명
                chrome.FindElement(By.XPath("//textarea[@id='shopProductCaption']")).SendKeys(item.상세정보.ToString().Replace("\\n", "\n"));
                //검색키워드
                chrome.FindElement(By.XPath("//input[@id='shopProductMetaKeywords']")).SendKeys(item.검색.ToString().Replace("\"", "").Replace("|", ","));
                //상세이미지
                string imagePath = "";
                var images_detail = item.상세이미지.ToString().Split('|');
                for (int pos = 0; pos < images_detail.Length; pos++)
                {
                    if (string.IsNullOrEmpty(imgFilePath))
                    {
                        imagePath += $"\"{images_detail[pos].Replace("\"", "").Replace(" ", "%20")}\" ";
                    }
                    else
                    {
                        imagePath += $"\"{imgFilePath}\\{images_detail[pos].Replace("\"", "").Replace(" ", "%20")}\" ";
                    }
                    //이미지 3개마다 업로드
                    if (pos % 3 == 2) 
                    {
                        chrome.FindElement(By.Id("cke_46")).Click();
                        Thread.Sleep(1000);
                        SendKeys.SendWait($"{imagePath}");
                        SendKeys.SendWait(@"{Enter}");
                        Thread.Sleep(2000);
                        imagePath = "";
                    }
                }
                if (!string.IsNullOrEmpty(imagePath)) 
                {
                    chrome.FindElement(By.Id("cke_46")).Click();
                    Thread.Sleep(1000);
                    SendKeys.SendWait($"{imagePath}");
                    SendKeys.SendWait(@"{Enter}");
                    Thread.Sleep(2000);
                }
           
              

                //저장
                try
                {
                    var element = chrome.FindElement(By.Id("saveShopProduct"));

                    Actions actions = new Actions(chrome);

                    actions.MoveToElement(element);

                    actions.Perform();
                    chrome.FindElement(By.XPath("//div[@class='right-header']//button[@id='saveShopProduct']")).Click();
                    Thread.Sleep(2000);
                    dataGridView.Rows[i].Cells[1].Value = "완료";
                }
                catch (Exception e)
                {
                    dataGridView.Rows[i].Cells[1].Value = "실패";
                }

            }
            //상품 추가
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView.ColumnCount > 0)
            {
                imgFilePath = tbFolderPath.Text;
                Thread thread = new Thread(new ThreadStart(delegate () // thread 생성
                {

                    //업로드
                    sendDataWithWeb();
                }));
                thread.Start();

            }
            else
            {
                MessageBox.Show("파일을 선택해주세요!! ");
            }
        }
    }
}
