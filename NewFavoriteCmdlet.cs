using System.Management.Automation;

namespace PowerShellTypeAdapter
{
    using System.Collections.Generic;

    [Cmdlet(VerbsCommon.New,"Favorite")]
    [OutputType(typeof(FavoriteStuff))]
    public class NewFavoriteCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public int FavoriteNumber { get; set; }

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateSet("Cat", "Dog", "Horse")]
        public string FavoritePet { get; set; } = "Dog";

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
            this.WriteVerbose("Begin!");
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            var dictionary = new Dictionary<string, object>
            {
                {"FavoriteNumber", this.FavoriteNumber},
                {"FavoritePet", this.FavoritePet}
            };

            this.WriteObject(new Favorite(dictionary));
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
            this.WriteVerbose("End!");
        }
    }

    public class FavoriteStuff
    {
        public int FavoriteNumber { get; set; }
        public string FavoritePet { get; set; }
    }
}
