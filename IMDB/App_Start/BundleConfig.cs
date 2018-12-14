using System.IO;
using System.Security.Cryptography;
using System.Web;
using System.Web.Hosting;
using System.Web.Optimization;

namespace IMDB
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include("~/Scripts/angular.js")
                .Include("~/Scripts/angular-ui-router.js")
                .Include("~/Angular/app.js")
                .Include("~/Angular/Actors/*.js")
                .Include("~/Angular/Movies/*.js"));

            foreach (var bundle in bundles)
            {
                bundle.Transforms.Add(new FileHashVersionBundleTransform());
            }
        }

        public class FileHashVersionBundleTransform : IBundleTransform
        {
            public void Process(BundleContext context, BundleResponse response)
            {
                foreach (var file in response.Files)
                {
                    using (FileStream fs = File.OpenRead(HostingEnvironment.MapPath(file.IncludedVirtualPath)))
                    {
                        //get hash of file contents
                        byte[] fileHash = new SHA256Managed().ComputeHash(fs);

                        //encode file hash as a query string param
                        string version = HttpServerUtility.UrlTokenEncode(fileHash);
                        file.IncludedVirtualPath = string.Concat(file.IncludedVirtualPath, "?v=", version);
                    }
                }
            }
        }
    }
}
