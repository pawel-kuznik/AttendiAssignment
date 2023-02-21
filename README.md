# REST API + Management UI

In this directory is a C# solution that runs a REST API (with a docker file to
create a docker image) and a separate directory that constain JS and HTML for
a management UI.

Admittely, the solution could be improved in both visuals and functionality.
However, I was trying to keep with the limit of 4 hours for the whole assignment.

## How to use it?

The `AttendiRestAPI` directory contains a Docker image suitable for running a local
REST API. One can run it via docker or via Visual Studio. Either option will result
in a development image running with a swagger UI in a browser.

The `ManagementUI` directory contains a simple (and I can't stress enough, how simple
it is) UI to communicate with the REST API. Just double click the `index.html` and
the browser will run for you.