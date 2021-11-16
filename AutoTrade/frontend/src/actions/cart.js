import cartService from "../services/cart.service";
import { CART_ADD_PRODUCT, CART_LOAD_PRODUCT } from "../constants/actionTypes";

export const AddCartProduct = (product) => async (dispatch) => {
    try {
        const {data} = await cartService.add(product);
        // const data = {
        //     id: product.productId,
        //     productName: "Сало",
        //     productImage: "/images/",
        //     productPrice: 432,
        //     quantity: 1
        // };
        dispatch({type: CART_ADD_PRODUCT, payload: data});
        return Promise.resolve();

    }
    catch(err) {
        const {data} = err.response;
        return Promise.reject(data);
    }
}


export const getCartUser = () => async (dispatch) => {
    const {data} = await cartService.list();
    dispatch({type: CART_LOAD_PRODUCT, payload: data});
} 