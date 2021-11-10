import http from '../http_common';

class UserService {
    getdata() {
        return http.get("api/account/get");        
    }  
}

export default new UserService();