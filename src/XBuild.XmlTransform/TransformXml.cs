using System.Xml;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Microsoft.Web.XmlTransform;

namespace XBuild.XmlTransform
{
    public class TransformXml : Task
    {
        [Required]
        public ITaskItem Destination { get; set; }

        [Required]
        public ITaskItem Source { get; set; }

        [Required]
        public ITaskItem Transform { get; set; }

        public override bool Execute()
        {
            var originalFileXml = new XmlDocument();
            originalFileXml.Load(Source.ItemSpec);

            using (var xmlTransform = new XmlTransformation(Transform.ItemSpec))
            {
                if (xmlTransform.Apply(originalFileXml) == false)
                {
                    return false;
                }

                // originalFileXml is now transformed
                originalFileXml.Save(Destination.ItemSpec);
            }

            return true;
        }
    }
}