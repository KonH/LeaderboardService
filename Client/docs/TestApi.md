# IO.Swagger.Api.TestApi

All URIs are relative to *https://localhost/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiTestCleanupPost**](TestApi.md#apitestcleanuppost) | **POST** /api/Test/cleanup | 
[**ApiTestPreparePost**](TestApi.md#apitestpreparepost) | **POST** /api/Test/prepare | 


<a name="apitestcleanuppost"></a>
# **ApiTestCleanupPost**
> void ApiTestCleanupPost ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiTestCleanupPostExample
    {
        public void main()
        {
            
            var apiInstance = new TestApi();

            try
            {
                apiInstance.ApiTestCleanupPost();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TestApi.ApiTestCleanupPost: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apitestpreparepost"></a>
# **ApiTestPreparePost**
> void ApiTestPreparePost ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiTestPreparePostExample
    {
        public void main()
        {
            
            var apiInstance = new TestApi();

            try
            {
                apiInstance.ApiTestPreparePost();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TestApi.ApiTestPreparePost: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

