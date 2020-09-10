import { atom } from 'recoil';

const authActivePanel = atom({
    key: 'activePanel',
    default: 'login'
});
export default  authActivePanel;