# CelestialBodies_MVC

``` $ dotnet new mvc --use-program-main ```

``` $ dotnet add package Microsoft.EntityFrameworkCore.SqlServer ```

``` $ podman build -t celestialbodies_mvc -f Containerfile . ```

``` $ podman run --detach --rm --network=host --name celestialbodies_mvc celestialbodies_mvc ```
