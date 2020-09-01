import config from "../../config";

export const srv = {
    auth_getVerificationCode: `${config.apiGateway.URL}Verification/GetCode`
}