Jekyll.Wordpress.Permalink.Redirect.Generator
=============================================

*This is a Windows (.Net 4.5) executable*

If you import posts from Wordpress into your jekyll site you may need to redirect requests to `/index.php/2014/04/15/foo-bar` to your permalink format, in my case `/:year/:month/:day/:title/`. This assumes you can use the [jekyll-redirect-from gem](https://github.com/jekyll/jekyll-redirect-from) which is supported by GitHub pages.

# Pre-Requisites

* Make sure you have imported your posts using e.g. `jekyll import wordpressdotcom --source wordpress.xml`
* Set the permalink style by adding the code below to your _config.yml
```YAML
permalink: /:year/:month/:day/:title/
```
* Make sure you are using the [jekyll-redirect-from gem](https://github.com/jekyll/jekyll-redirect-from) by adding the following to your _config.yml file
```YAML
gems:
- jekyll-redirect-from
```
* Run `bundle` to install the necessary gem above
* Run Jekyll.Wordpress.Permalink.Redirect.Generator specifying the _posts folder
```
Jekyll.Wordpress.Permalink.Redirect.Generator.exe c:\path\to\my\site\_posts
```
* Check the output


