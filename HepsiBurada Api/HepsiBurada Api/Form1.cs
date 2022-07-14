using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HepsiBurada_Api
{
    public partial class Form1 : Form
    {
        string username = "xx";
        string password = "xx";
        string merchantId = "xx";
        public Form1()
        {
            InitializeComponent();
        }
        IRestResponse Urunlistegetir(string username, string password, string merchantId)
        {
            var client = new RestClient("https://listing-external-sit.hepsiburada.com/listings/merchantid/" + merchantId);
            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password));
            var request = new RestRequest(Method.GET);
            request.AddHeader("merchantid", merchantId);
            request.AddHeader("content-type", "application/xml");
            request.AddHeader("Authorization", "Basic " + svcCredentials);
            IRestResponse response = client.Execute(request) as RestResponse;
            return response;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UrunListeGoster();
        }

     //   Şimdi Urunlistegetir Yordamımızı Çağıralım

        void UrunListeGoster()
        {
           

            IRestResponse urunListe = Urunlistegetir(username, password, merchantId);
            //Durum Kodu 'Ok' ise
            if (urunListe.StatusCode == HttpStatusCode.OK)
            {
                MessageBox.Show(urunListe.Content);
            }
            //Durum Kodu 'Ok' değilse
            else
            {
                MessageBox.Show(urunListe.StatusCode.ToString());
            }
        }

        /*   Ürünlerin Güncellenmesi

           Hepsiburada üzerinde ürünlerin fiyat, stok adedi, bir defada maksimum satınalma miktarı gibi alanlar güncellenebiliyor.

           Bu güncellemeyi aşağıda gösterilen string üzerinde yapıyoruz.Daha sonra upload yapıyoruz.

           stringimiz
        */
        // Birden fazla listing var ise ister <listing> </listing> arasına yazıp for ile göndürürsünüz isterse alt alta yazabilirsiniz 

        string strXml = @"<listings>
      
         <listing>
        <UniqueIdentifier></UniqueIdentifier>
        <HepsiburadaSku>ZYHPCOCACCOL055</HepsiburadaSku>
        <MerchantSku>COLA123</MerchantSku>
        <ProductName>Coca Cola Cam 200 Ml</ProductName>
        <Price>6000</Price>
        <AvailableStock>100</AvailableStock>
        <DispatchTime>1</DispatchTime>
        <CargoCompany1>Yurtiçi Kargo</CargoCompany1>
        <CargoCompany2>Aras Kargo</CargoCompany2>
        <CargoCompany3>Horoz Lojistik</CargoCompany3>
        <MaximumPurchasableQuantity>4</MaximumPurchasableQuantity>
        </listing>
    
        <listing>
        <UniqueIdentifier></UniqueIdentifier>
        <HepsiburadaSku>ZYHPCOCACCOL055</HepsiburadaSku>
        <MerchantSku>COLA123</MerchantSku>
        <ProductName>Coca Cola Cam 200 Ml</ProductName>
        <Price>6000</Price>
        <AvailableStock>100</AvailableStock>
        <DispatchTime>1</DispatchTime>
        <CargoCompany1>Yurtiçi Kargo</CargoCompany1>
        <CargoCompany2>Aras Kargo</CargoCompany2>
        <CargoCompany3>Horoz Lojistik</CargoCompany3>
        <MaximumPurchasableQuantity>4</MaximumPurchasableQuantity>
        </listing>
    

    </listings>";


            string UrunGuncelle(string username, string password, string merchantId, string strXml)
            {
                var uri = "https://listing-external-sit.hepsiburada.com/listings/merchantid/" + merchantId + "/inventory-uploads";
                var client = new RestClient(uri);
                var request = new RestRequest(Method.POST);
                string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password));

                request.AddHeader("merchantid", merchantId);
                request.AddHeader("Authorization", "Basic " + svcCredentials);

                request.RequestFormat = RestSharp.DataFormat.Xml;

                if (!string.IsNullOrEmpty(strXml))
                    request.AddParameter("application/xml", strXml, ParameterType.RequestBody);

                var result = "";
                var response = client.Execute(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    result = response.Content;
                    Console.WriteLine(result);
                }
                else
                {
                    result = response.StatusCode.ToString();
                }
                return result;

            }

        private void button2_Click(object sender, EventArgs e)
        {
             UrunGuncelle( username,  password,  merchantId,  strXml);
        }
    }
}
