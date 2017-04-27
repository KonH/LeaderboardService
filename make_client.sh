#/bin/sh
swagger-codegen generate -i http://127.0.0.1:8080/swagger/v1/swagger.json -l csharp -o Client
