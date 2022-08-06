using Pulumi;
using Pulumi.AzureNative.Resources;
using Pulumi.AzureNative.Storage;
using Pulumi.AzureNative.Storage.Inputs;

class StackTwo : Stack
{
    public StackTwo()
    {
        var stackOne = new StackReference("devone");
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