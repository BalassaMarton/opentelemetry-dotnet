# Changelog

## Unreleased

* Introduced support for Grpc.AspNetCore (#803).
  * Attributes are added to gRPC invocations: `rpc.system`, `rpc.service`,
    `rpc.method`. These attributes are added to an existing span generated by
    the instrumentation. This is unlike the instrumentation for client-side
    gRPC calls where one span is created for the gRPC call and a separate span
    is created for the underlying HTTP call in the event both gRPC and HTTP
    instrumentation are enabled.

## 0.3.0-beta

Released 2020-07-23

* Initial release
