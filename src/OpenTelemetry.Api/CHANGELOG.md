# Changelog

## Unreleased

* Introduced `RuntimeContext` API
([#948](https://github.com/open-telemetry/opentelemetry-dotnet/pull/948)).
* Link constructor changed to accept ActivityTagsCollection instead of
  IDictionary<string, object> attributes.
* TelemetrySpan adds more overloads for SetAttribute with value of type bool,
int, double (string already existed).
* TelemetrySpan's SetAttribute behavior
changed to match the
[spec](https://github.com/open-telemetry/opentelemetry-specification/blob/master/specification/trace/api.md#set-attributes).
  * Setting an attribute with an existing key now results in overwriting it.
  * Setting null value has no impact except if null is set to an existing key, it
  gets removed.
    ([#954](https://github.com/open-telemetry/opentelemetry-dotnet/pull/954)).
* HttpStatusCode in all spans attribute (http.status_code) to use int value.
* `ITextFormatActivity` got replaced by `ITextFormat` with an additional method
  to be implemented (`IsInjected`)
* Added `CompositePropagator` that accepts a list of `ITextFormat` following
  [specification](https://github.com/open-telemetry/opentelemetry-specification/blob/master/specification/context/api-propagators.md#create-a-composite-propagator)
* Added `StartRootSpan`, `StartActiveSpan` and modified `StartSpan` API.
  ([#989](https://github.com/open-telemetry/opentelemetry-dotnet/issues/989)).
   Modified StartSpan not to set the created span as Active to match
  [spec](https://github.com/open-telemetry/opentelemetry-specification/blob/master/specification/trace/api.md#span-creation).

## 0.4.0-beta.2

Released 2020-07-24

* First beta release

## 0.3.0-beta

Released 2020-07-23

* Initial release
