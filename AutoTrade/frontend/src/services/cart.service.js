import http from "../http_common";

class CartService {

    add(data) {
        return http.post("api/carts/add", data);
    }

    list() {
        return http.get("api/carts/list");
    }
}

export default new CartService(); 