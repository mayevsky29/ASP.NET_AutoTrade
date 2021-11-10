import http from "../http_common";

class AuthService {

    register(data) {
        return http.post("api/account/register", data,
        {
            headers: {
                'Content-Type': 'multipart/form-data'
            }
        });
    }

    login(data) {
        return http.post("api/account/login", data, {
            headers: {
                'Content-Type': 'application/json'
            }
        });
    }
    getusers(data) {
        return http.get("api/account/get", data, {
            headers: {
                'Content-Type': 'application/json'
            }
        });
    }
}

export default new AuthService();