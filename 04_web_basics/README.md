# WEB BASICS

## HTTP

Protocol for communication over the internet.

`Client-Server model` HTTP follows client-server model, which means a `client`
(browser) makes a `request` to `server` and the server returns a `response`.

`Request Methods` are indicators for user intention.
- `POST` I want to create/store data.
- `GET` I want to read/retrieve data.
- `PUT` I want to update/change data.
- `DELETE` I want to delete data.

`URL` Uniform Resource Locator is a string used to locate resource on internet.
- `Protocol` for communication `http://`, `https://`, `ftp://`.
- `Host` or `IP` i.e. `www.softuni.bg`, `127.0.0.1`.
- `Port` the default is `:8080`, it is hidden in the url bar.
- `Path` to a resource `/users`.
- `Query params` details the server uses to get the resource `?age=27&gender=m`.
- `Fragment` used on client to navigate to certain section `#lectures`

`MIME` Stands for Multipurpose Internet Mail Extensions and is a set of
predefined resource types that will be transmitted over the internet. A server
can specify the resource type in its response and the browser will know how to
interpret it.
- `application/json` is JSON data.
- `application/pdf` is PDF document.
- `image/png` is PNG image.
- `text/html` is HTML.
- `text/plain` is plain text.
- `video/mp4` is mp4 video.

`Headers` Additional information sent in requests and responses.
- `Host` added by default, specifies the domain name of the server
requested.
- `User-Agent` added by default, specifies the client making request.
- `Content-Type` added only when request/response body exists and specifies the
data type sent in the body.

`Status Codes` Codes that indicate the status of response.
- `1xx` informational (i.e. `100 Continue`)
- `2xx` successful (i.e. `200 OK`)
- `3xx` redirection (i.e. `301 Moved Permanently`)
- `4xx` client error (i.e. `400 Bad Request`)
- `5xx` server error (i.e. `500 Internal Server Error`)

`HTTP Request Content`
- `Request Line` contains Request method, URL and Protocol version.
- `Request Headers` contains additional information sent by client.
- `Request Body` optional data.

`HTTP Response Content`
- `Response Status Line` contains Protocol version, Status code and Status text.
- `Response Headers` contains additional information sent by server.
- `Response Body` optional data.
