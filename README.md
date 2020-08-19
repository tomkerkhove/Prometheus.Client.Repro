Repro for Prometheus.Client #113
===

Repro for Prometheus.Client [#113](https://github.com/PrometheusClientNet/Prometheus.Client/issues/113).

## Running it

1. Run image
2. Go to http://localhost:32768/weatherforecast to trigger a write
3. See written metrics on http://localhost:32768/metrics

```prometheus
# HELP example Sample metric
# TYPE example gauge
example 0 0
example{instance="local",region="europe"} 100 1597840168812
```