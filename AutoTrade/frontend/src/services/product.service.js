import http from "../http_common";

class ProductService {

    list() {
        return http.get("api/products/list");
    }
}

export default new ProductService(); 