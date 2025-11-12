public class ServiceRequestNode
{
    public ServiceRequest Data { get; set; }
    public ServiceRequestNode Left { get; set; }
    public ServiceRequestNode Right { get; set; }

    public ServiceRequestNode(ServiceRequest data)
    {
        Data = data;
    }
}

public class ServiceRequestBST
{
    public ServiceRequestNode Root { get; private set; }

    public void Insert(ServiceRequest req)
    {
        Root = InsertRec(Root, req);
    }

    private ServiceRequestNode InsertRec(ServiceRequestNode node, ServiceRequest req)
    {
        if (node == null)
            return new ServiceRequestNode(req);
        if (req.Id < node.Data.Id)
            node.Left = InsertRec(node.Left, req);
        else
            node.Right = InsertRec(node.Right, req);
        return node;
    }

    public List<ServiceRequest> InOrder()
    {
        List<ServiceRequest> result = new List<ServiceRequest>();
        InOrderRec(Root, result);
        return result;
    }

    private void InOrderRec(ServiceRequestNode node, List<ServiceRequest> list)
    {
        if (node != null)
        {
            InOrderRec(node.Left, list);
            list.Add(node.Data);
            InOrderRec(node.Right, list);
        }
    }
}
