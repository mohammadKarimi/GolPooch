import { atom } from 'recoil';

//** this state has saved user information **//
export default userInfo = atom({
    key: 'userInfo',
    default: {},
});
