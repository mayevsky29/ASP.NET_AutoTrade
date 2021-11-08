import http from "../../http_common";

export class ProductService {

    list() {
        return http.get("api/products/list");
    }

    getProductsSmall() {
        return fetch('products-small.json').then(res => res.json()).then(d => d.data);
    }

    getProducts() {
        return fetch('products.json').then(res => res.json()).then(d => {
            console.log("data", d.data);
            return Promise.resolve(d.data); 
        });
    }

    getProductsWithOrdersSmall() {
        return fetch('products-orders-small.json').then(res => res.json()).then(d => d.data);
    }
} 