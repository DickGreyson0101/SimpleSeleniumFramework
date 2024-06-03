using APITesting.Model;
using FluentAssertions;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using TestFrameworkCore.Helper;

namespace APITesting.Test
{
    [TestClass]
    public class UserAPITest
    {
        private RestClient client;

         [TestInitialize]
        public void TestInitialize()
        {
            var url = ConfigurationHelper.GetConfig<string>("url");
            client = new RestClient(url);
        }

        [TestMethod("TC07 : Get list users")]
        public void VerifyGetListUser()
        {
           
            int randomPage = new Random().Next(1,11);
            var request = new RestRequest($"/api/users?page={randomPage}", Method.Get);
            RestResponse response = client.Execute(request);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            GetUserModel model = JsonConvert.DeserializeObject<GetUserModel>(response.Content);
            model.page.Should().Be(randomPage);

        }
        [TestMethod("TC06: Create a new user")]
        public void VerifyCreateNewUser()
        {
            
            var request = new RestRequest("/api/users", Method.Post);

            // khai bao model va data de gui len api
            var requestModel = new CreateUserRequestModel
            {
                Name = "Linh" + DateTime.Now.ToFileTimeUtc(),
                    Job = "Automation Tester",

            };
            request.AddJsonBody(requestModel);
            RestResponse response = client.Execute(request);
            //Assertion
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var responseModel = JsonConvert.DeserializeObject<CreateUserResponseModel>(response.Content);
            responseModel.Name.Should().Be(requestModel.Name);
            responseModel.Job.Should().Be(requestModel.Job);
        }
    }
}
