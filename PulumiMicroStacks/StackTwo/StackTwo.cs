using Pulumi;
using Pulumi.AzureNative.Resources;
using Pulumi.AzureNative.Storage;
using Pulumi.AzureNative.Storage.Inputs;

class StackTwo : Stack
{
    public StackTwo()
    {
        var config = new Config();
        var stackOne = new StackReference($"SzymonSmykala/StackOne/devone");
        var resourceGroupName = stackOne.GetOutput("ResourceGroupName");
        
        var storageAccount = new StorageAccount("sa", new StorageAccountArgs
        {
            ResourceGroupName = resourceGroupName.Apply(x => x!.ToString())!,
            Sku = new SkuArgs
            {
                Name = SkuName.Standard_LRS
            },
            Kind = Kind.StorageV2
        });
    }
}