using Pulumi;
using Pulumi.AzureNative.Resources;

class StackOne : Stack
{
    [Output()] public Output<string> ResourceGroupName { get; set; }

    public StackOne()
    {
        var rg = new ResourceGroup("ResourceGroup");
        ResourceGroupName = rg.Name;
    }

}