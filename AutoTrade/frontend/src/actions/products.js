import productService from "../services/product.service";
import { PRODUCT_LIST } from "../constants/actionTypes";

export const ListProduct = () => async (dispatch) => {
    try {
        const {data} = await productService.list();
        dispatch({type: PRODUCT_LIST, payload: data});
        return Promise.resolve();

    }
    catch(err) {
        const {data} = err.response;
        return Promise.reject(data);
    }
}