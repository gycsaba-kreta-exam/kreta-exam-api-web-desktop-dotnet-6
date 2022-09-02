﻿using Newtonsoft.Json;
using System.Text;
using System.Net;
using KretaParancssoriAlkalmazas.Models.DataModel;
using ApplicationPropertiesSettings;
using KretaParancssoriAlkalmazas.Models.Pagination;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection.Metadata;
using ServiceKretaAPI.Lib;
using KretaParancssoriAlkalmazas.Models.Parameters;
using Microsoft.Extensions.Primitives;

namespace ServiceKretaAPI.Services
{
    public class SubjectService : ISubjectService
    {
        public async Task<List<Subject>>? GetSubjectsAsync(QueryStringParameters queryStringParameter)
        {
            if (queryStringParameter == null)
            {
                queryStringParameter = new QueryStringParameters();
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = GetHttpClientUri();

                StringBuilder query = new StringBuilder("/Subject/api/subject");
                query.Append(queryStringParameter.ToQueryString);

                var respons = await client.GetAsync(query.ToString());

                var content = respons.Content.ReadAsStringAsync();
#pragma warning disable CS8603 // Possible null reference return.
                return JsonConvert.DeserializeObject<List<Subject>>(content.Result);
#pragma warning restore CS8603 // Possible null reference return.
            }
        }

        public async Task<ListWithPaginationData<Subject>>? GetSubjectsAsyncWithPageData(QueryStringParameters queryStringParameter)
        {
            if (queryStringParameter == null)
            {
                queryStringParameter = new QueryStringParameters();
            }

            ListWithPaginationData<Subject> listWithPaginationData = new ListWithPaginationData<Subject>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = GetHttpClientUri();

                StringBuilder query = new StringBuilder("/Subject/api/subject");
                query.Append(queryStringParameter.ToQueryString);
                
                var respons = await client.GetAsync(query.ToString());

                var content = respons.Content.ReadAsStringAsync();
#pragma warning disable CS8603 // Possible null reference return.
                List<Subject> subjects = JsonConvert.DeserializeObject<List<Subject>>(content.Result);
#pragma warning restore CS8603 // Possible null reference return.
                
                listWithPaginationData.Items = subjects;

                ApiHeaderHandler apiHeaderHandler = new ApiHeaderHandler();
                listWithPaginationData.NumberOfPage= apiHeaderHandler.GetHeaderParameter(respons, "X-Pagination", "NumberOfPage");
                listWithPaginationData.CurrentPage = apiHeaderHandler.GetHeaderParameter(respons, "X-Pagination", "CurrentPage");
                listWithPaginationData.PageSize = apiHeaderHandler.GetHeaderParameter(respons, "X-Pagination", "PageSize");
                listWithPaginationData.NumberOfRows=apiHeaderHandler.GetHeaderParameter(respons, "X-Pagination", "NumberOfRows");                
            }
            return listWithPaginationData;
        }




        public async Task<Subject>? GetSubjectByIdAsync(long id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = GetHttpClientUri();

                var respons = await client.GetAsync("Subject/api/subject/" + id.ToString());

                var content = respons.Content.ReadAsStringAsync();

#pragma warning disable CS8603 // Possible null reference return.
                return JsonConvert.DeserializeObject<Subject>(content.Result);
#pragma warning restore CS8603 // Possible null reference return.

            }
        }

        public async Task<long> GetNextSubjectIdAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = GetHttpClientUri();

                var result = await client.GetAsync("/Subject/api/subject?orderBy=subjectName");

                ApiHeaderHandler apiHeaderHandler = new ApiHeaderHandler();
                int id = apiHeaderHandler.GetHeaderParameter(result, "X-NextId","NextId");
                return id;
            }
        }

        public async Task<System.Net.HttpStatusCode> InsertNewSubjectAsync(Subject subject)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = GetHttpClientUri();

                String jsonString = JsonConvert.SerializeObject(subject);
                StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("/Subject/api/subject", httpContent);

                //string error = "" + response.Content + " : " + response.StatusCode;
                return response.StatusCode;
            }
        }

        public async Task<HttpStatusCode> UpdateSubjectAsync(long id, Subject subject)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = GetHttpClientUri();
                String jsonString = JsonConvert.SerializeObject(subject);
                StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync("Subject/api/subject/" + id.ToString(), httpContent);

                return response.StatusCode;
            }
        }

        public async Task<HttpStatusCode> DeleteSubjectAsync(long id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = GetHttpClientUri();

                var response = await httpClient.DeleteAsync("Subject/api/subject/" + id.ToString());

                return response.StatusCode;
            }
        }

        private Uri GetHttpClientUri()
        {
            UriBuilder uri = new UriBuilder();
            uri = ApplicationProperties.GetAPIUri(uri);
            return uri.Uri;
        }
    }
}


