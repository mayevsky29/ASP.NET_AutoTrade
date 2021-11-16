import { CART_ADD_PRODUCT, CART_LOAD_PRODUCT } from "../constants/actionTypes";

const initialState = {
    list: [], //товари в кошику
    count: 0 //кількість товарів в кошику
}

const cartReducer = (state = initialState, action) => {
    const { type, payload } = action;
    switch (type) {
        case CART_ADD_PRODUCT: {
            const list = state.list.filter(item => item.id !== payload.id);
            return {
                ...state,
                list: [...list, payload],
                count: state.count + 1
            };
        }
        case CART_LOAD_PRODUCT: {
            let quantityAll = 0;
            for (let i = 0; i < payload.length; i++) {
                quantityAll += payload[i].quantity;
            }
            return {
                ...state,
                list: payload,
                count: quantityAll
            }
        }
        default: {
            return state;
        }
    }


}

export default cartReducer;