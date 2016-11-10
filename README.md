# HMUDJSMinifier
This is an application will take javascript files, minify them, and then automatically output the minified version to the hackmud folder.
If you have more than one user, you can choose which user folder to export to.
Before using this, setup the app.config so that the script path setting contains your folder you use to develop scripts.
You can also setup a default script file to minify, so you can just hit enter when it asks for a file name.
If you want the minified version to append text to the minified file name, you can add that in the config as well. By default, it's blank.

This application makes use of the Microsoft Ajax Minifier library: http://ajaxmin.codeplex.com/wikipage?title=AjaxMin%20DLL

Hopefully someone else finds this useful.
