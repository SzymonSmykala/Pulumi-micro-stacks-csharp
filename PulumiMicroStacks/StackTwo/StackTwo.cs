using Pulumi;
using Pulumi.AzureNative.Resources;
using Pulumi.AzureNative.Storage;
using Pulumi.AzureNative.Storage.Inputs;

class StackTwo : Stack
{
    public StackTwo()
    {
        const string orgName = "SzymonSmykala";
        const string projectName = "StackOne";
        const string stackName = "devone";
        
        var stackOne = new StackReference($"{orgName}/{projectName}/{stackName}");
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