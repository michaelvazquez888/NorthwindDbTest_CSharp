<%@ Page Title="Product Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="NorthwindDbTest_CSharp.ProductDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="./">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">Product Details</li>
            </ol>
        </nav>

        <h2 id="title"><%: Title %></h2>

        <div class="table-responsive mb-3">
            <% if (Product != null)
                { %>
            <table class="table table-striped table-sm">
                <thead class="table-primary">
                    <tr>
                        <th scope="col">Id</th>
                        <th scope="col">Name</th>
                        <th scope="col">Supplier</th>
                        <th scope="col">Category</th>
                        <th scope="col">Quantity Per Unit</th>
                        <th scope="col">Unit Price</th>
                        <th scope="col">Units In Stock</th>
                        <th scope="col">Units On Order</th>
                        <th scope="col">Reorder Level</th>
                    </tr>
                </thead>

                <tbody>
                    <tr>
                        <td><%: Product.Id %></td>
                        <td><%: Product.Name %></td>
                        <td><%: Product.Supplier.CompanyName %></td>
                        <td><%: Product.Category.Name %></td>
                        <td><%: Product.QuantityPerUnit %></td>
                        <td><%: Product.UnitPrice %></td>
                        <td><%: Product.UnitsInStock %></td>
                        <td><%: Product.UnitsOnOrder %></td>
                        <td><%: Product.ReorderLevel %></td>
                    </tr>
                </tbody>
            </table>
            <% }
                else
                {%>
                    No Product found.
            <% } %>
        </div>

        <h2><%: OrdersTitle %></h2>

        <div class="table-responsive">
            <% if (Orders != null && Orders.Any()) { %>
                <table id="OrdersTable" class="table table-striped table-sm accordion">
                    <thead class="table-primary">
                        <tr>
                            <th scope="col">Id</th>
                            <th scope="col">Customer Id</th>
                            <th scope="col">Employee Id</th>
                            <th scope="col">Order Date</th>
                            <th scope="col">Required Date</th>
                            <th scope="col">Shipped Date</th>
                            <th scope="col">Ship Via</th>
                            <th scope="col">Freight</th>
                            <th scope="col">Ship Name</th>
                            <th scope="col">Ship Address</th>
                            <th scope="col">Unit Price</th>
                            <th scope="col">Quantity</th>
                            <th scope="col">Discount</th>
                        </tr>
                    </thead>

                    <tbody>
                        <% foreach (var order in Orders) { %>
                            <tr data-bs-toggle="collapse" data-bs-target="<%: "#Order" + order.Id.ToString() + "Details" %>">
                                <td><%: order.Id %></td>
                                <td><%: order.CustomerId %></td>
                                <td><%: order.EmployeeId %></td>
                                <td><%: order.OrderDate.ToShortDateString() %></td>
                                <td><%: order.RequiredDate.ToShortDateString() %></td>
                                <td><%: order.ShippedDate.HasValue ? order.ShippedDate.Value.ToShortDateString() : "" %></td>
                                <td><%: order.ShipVia %></td>
                                <td><%: order.Freight %></td>
                                <td><%: order.ShipName %></td>
                                <td>
                                    <% if (order.ShipAddress != null) { %>
                                        <%: order.ShipAddress.Street + " " + order.ShipAddress.City + " " + order.ShipAddress.Region 
                                                + " " + order.ShipAddress.PostalCode + " " + order.ShipAddress.Country + " " + order.ShipAddress.Phone %>
                                    <% } %>
                                </td>
                                <td><%: order.Details.FirstOrDefault()?.UnitPrice %></td>
                                <td><%: order.Details.FirstOrDefault()?.Quantity %></td>
                                <td><%: order.Details.FirstOrDefault()?.Discount %></td>
                            </tr>
                        <% } %>
                    </tbody>
                </table>
            <% } else { %>
                No Orders found.
            <% } %>
        </div>
    </div>
</asp:Content>