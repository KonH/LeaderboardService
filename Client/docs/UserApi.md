# IO.Swagger.Api.UserApi

All URIs are relative to *https://localhost/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiUserByNameDelete**](UserApi.md#apiuserbynamedelete) | **DELETE** /api/User/{name} | 
[**ApiUserByNameGet**](UserApi.md#apiuserbynameget) | **GET** /api/User/{name} | 
[**ApiUserByNamePatch**](UserApi.md#apiuserbynamepatch) | **PATCH** /api/User/{name} | 
[**ApiUserGet**](UserApi.md#apiuserget) | **GET** /api/User | 
[**ApiUserPost**](UserApi.md#apiuserpost) | **POST** /api/User | 


<a name="apiuserbynamedelete"></a>
# **ApiUserByNameDelete**
> void ApiUserByNameDelete (string name, string authorization = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiUserByNameDeleteExample
    {
        public void main()
        {
            
            var apiInstance = new UserApi();
            var name = name_example;  // string | 
            var authorization = authorization_example;  // string |  (optional) 

            try
            {
                apiInstance.ApiUserByNameDelete(name, authorization);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.ApiUserByNameDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**|  | 
 **authorization** | **string**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiuserbynameget"></a>
# **ApiUserByNameGet**
> void ApiUserByNameGet (string name, string authorization = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiUserByNameGetExample
    {
        public void main()
        {
            
            var apiInstance = new UserApi();
            var name = name_example;  // string | 
            var authorization = authorization_example;  // string |  (optional) 

            try
            {
                apiInstance.ApiUserByNameGet(name, authorization);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.ApiUserByNameGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**|  | 
 **authorization** | **string**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiuserbynamepatch"></a>
# **ApiUserByNamePatch**
> void ApiUserByNamePatch (string name, string authorization = null, User item = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiUserByNamePatchExample
    {
        public void main()
        {
            
            var apiInstance = new UserApi();
            var name = name_example;  // string | 
            var authorization = authorization_example;  // string |  (optional) 
            var item = new User(); // User |  (optional) 

            try
            {
                apiInstance.ApiUserByNamePatch(name, authorization, item);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.ApiUserByNamePatch: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**|  | 
 **authorization** | **string**|  | [optional] 
 **item** | [**User**](User.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/json-patch+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiuserget"></a>
# **ApiUserGet**
> List<User> ApiUserGet (string authorization = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiUserGetExample
    {
        public void main()
        {
            
            var apiInstance = new UserApi();
            var authorization = authorization_example;  // string |  (optional) 

            try
            {
                List&lt;User&gt; result = apiInstance.ApiUserGet(authorization);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.ApiUserGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **authorization** | **string**|  | [optional] 

### Return type

[**List<User>**](User.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiuserpost"></a>
# **ApiUserPost**
> void ApiUserPost (string authorization = null, User item = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiUserPostExample
    {
        public void main()
        {
            
            var apiInstance = new UserApi();
            var authorization = authorization_example;  // string |  (optional) 
            var item = new User(); // User |  (optional) 

            try
            {
                apiInstance.ApiUserPost(authorization, item);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.ApiUserPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **authorization** | **string**|  | [optional] 
 **item** | [**User**](User.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/json-patch+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

