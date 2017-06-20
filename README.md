# Draft REST API document
[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)
This document is use as a draft describing REST APIs for the project structure demo.There are only 2 features in the demo
  - Login/logout
  - CRUD user's profile
# Technology stack

  - ASP.NET core
  - Entity framework
  - JWT
  - Docker
# REST API Description 
<table style="text-align: center;">
<thead style="color: white; background-color: #999999; text-align: center;">
<tr>
<td rowspan="2">Feature</td>
<td rowspan="2">API</td>
<td rowspan="2">Description</td>
<td rowspan="2">Method</td>
<td rowspan="2">URL pattern</td>
<td colspan="2">Return codes</td>
</tr>
<tr>
<td>Success</td>
<td>Failure</td>
</tr>
</thead>
<tbody>
<tr>
<td rowspan="2">Authentication</td>
<td>login</td>
<td>Login using JWT</td>
<td>GET</td>
<td>api/v1/login</td>
<td>200</td>
<td>401</td>
</tr>
<tr>
<td>logout</td>
<td>Logout(invalidate token)</td>
<td>POST</td>
<td>api/v1/logout</td>
<td>200</td>
<td>500</td>
</tr>
<tr>
<td rowspan="5">UPM<br /><br /></td>
<td>create</td>
<td>Create a user with profile</td>
<td>POST</td>
<td>api/v1/upm/create</td>
<td>200</td>
<td>401,500</td>
</tr>
<tr>
<td>getAll</td>
<td>Get all the user profiles</td>
<td>GET</td>
<td>api/v1/upm/get</td>
<td>200</td>
<td>401,500</td>
</tr>
<tr>
<td>get</td>
<td>Get a specific user profile</td>
<td>GET</td>
<td>api/v1/upm/get/{id}</td>
<td>200</td>
<td>401,500</td>
</tr>
<tr>
<td>update</td>
<td>Update a user profile</td>
<td>POST</td>
<td>api/v1/upm/update/{id}</td>
<td>200</td>
<td>401,500</td>
</tr>
<tr>
<td>delete</td>
<td>Delete a user profile</td>
<td>DELETE</td>
<td>api/v1/upm/delete/{id}</td>
<td>200</td>
<td>401,500</td>
</tr>
</tbody>
</table>




You can also:
  - Import and save files from GitHub, Dropbox, Google Drive and One Drive
  - Drag and drop markdown and HTML files into Dillinger
  - Export documents as Markdown, HTML and PDF

Markdown is a lightweight markup language based on the formatting conventions that people naturally use in email.  As [John Gruber] writes on the [Markdown site][df1]

> The overriding design goal for Markdown's
> formatting syntax is to make it as readable
> as possible. The idea is that a
> Markdown-formatted document should be
> publishable as-is, as plain text, without
> looking like it's been marked up with tags
> or formatting instructions.

This text you see here is *actually* written in Markdown! To get a feel for Markdown's syntax, type some text into the left window and watch the results in the right.

### Tech

Dillinger uses a number of open source projects to work properly:

* [AngularJS] - HTML enhanced for web apps!
* [Ace Editor] - awesome web-based text editor
* [markdown-it] - Markdown parser done right. Fast and easy to extend.
* [Twitter Bootstrap] - great UI boilerplate for modern web apps
* [node.js] - evented I/O for the backend
* [Express] - fast node.js network app framework [@tjholowaychuk]
* [Gulp] - the streaming build system
* [Breakdance](http://breakdance.io) - HTML to Markdown converter
* [jQuery] - duh

And of course Dillinger itself is open source with a [public repository][dill]
 on GitHub.

### Plugins

Dillinger is currently extended with the following plugins. Instructions on how to use them in your own application are linked below.

| Plugin | README |
| ------ | ------ |
| Dropbox | [plugins/dropbox/README.md] [PlDb] |
| Github | [plugins/github/README.md] [PlGh] |
| Google Drive | [plugins/googledrive/README.md] [PlGd] |
| OneDrive | [plugins/onedrive/README.md] [PlOd] |
| Medium | [plugins/medium/README.md] [PlMe] |
| Google Analytics | [plugins/googleanalytics/README.md] [PlGa] |


### Docker

Running the backend application

#### Installation 
* [Windows](https://docs.docker.com/docker-for-windows/)
* [Ubuntu](https://docs.docker.com/engine/installation/linux/ubuntu/)
	On Ubuntu/Other Linux, make sure you have [docker-compose](https://docs.docker.com/compose/install/) installed.
	
After installing Docker, clone the backend source code at:
http://github.com/chuongdlb/aspnet-core-api

Step 1:
```sh
$ git clone http://github.com/chuongdlb/aspnet-core-api 
$ cd aspnet-core-api
```

Step  2 (Build):
```sh
$ docker-compose build
```

Step 3 - Run the app:
```sh
$ docker-compose up -d
```

License
----

MIT


**Free Software, Hell Yeah!**

[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)


   [dill]: <https://github.com/joemccann/dillinger>
   [git-repo-url]: <https://github.com/joemccann/dillinger.git>
   [john gruber]: <http://daringfireball.net>
   [df1]: <http://daringfireball.net/projects/markdown/>
   [markdown-it]: <https://github.com/markdown-it/markdown-it>
   [Ace Editor]: <http://ace.ajax.org>
   [node.js]: <http://nodejs.org>
   [Twitter Bootstrap]: <http://twitter.github.com/bootstrap/>
   [jQuery]: <http://jquery.com>
   [@tjholowaychuk]: <http://twitter.com/tjholowaychuk>
   [express]: <http://expressjs.com>
   [AngularJS]: <http://angularjs.org>
   [Gulp]: <http://gulpjs.com>

   [PlDb]: <https://github.com/joemccann/dillinger/tree/master/plugins/dropbox/README.md>
   [PlGh]: <https://github.com/joemccann/dillinger/tree/master/plugins/github/README.md>
   [PlGd]: <https://github.com/joemccann/dillinger/tree/master/plugins/googledrive/README.md>
   [PlOd]: <https://github.com/joemccann/dillinger/tree/master/plugins/onedrive/README.md>
   [PlMe]: <https://github.com/joemccann/dillinger/tree/master/plugins/medium/README.md>
   [PlGa]: <https://github.com/RahulHP/dillinger/blob/master/plugins/googleanalytics/README.md>
