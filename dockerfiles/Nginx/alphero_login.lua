--local crypto = require "crypto"
--local json = require "json"

function check_proof()
    local alphero_username_cookie_value = ngx.var["cookie_alphero_username"]
    local alphero_proof_cookie_value = ngx.var["cookie_alphero_proof"]
    if string.len(alphero_username_cookie_value)<1 ||
        string.len(alphero_proof_cookie_value)<1 then

        ngx.exit(ngx.HTTP_UNAUTHORIZED)
    end
    local expected_proof = calculate_proof(alphero_username_cookie_value)
    if expected_proof != alphero_proof_cookie_value then
        ngx.exit(ngx.HTTP_UNAUTHORIZED)
    end
end

function attempt_login()
    local reqType = ngx.var.request_method

    if reqType == ngx.HTTP_GET then 
        cgilua.htmlheader()
        cgilua.put([[
    <html>
        <head>
          <title>Hello World</title>
        </head>
        <body>
          <strong>Hello World!</strong>
        </body>
    </html>]])
        return
    elseif reqType == ngx.HTTP_POST then
        res = ngx.location.capture("/read_instance")
    else 
        error("invalid operation")
    end


    local data = ngx.req.read_body()
    local args = ngx.req.get_post_args(

    local password = ""
    local username = ""
    for key, val in pairs(args) do
        if key == "username" then
            username = val
        elseif key == "password" then
            password = val
        end
    end

    if string.len(username) <1 then
        ngx.exit(ngx.HTTP_UNAUTHORIZED)
    end

    if password != "test" then
        ngx.exit(ngx.HTTP_UNAUTHORIZED)
    end

    local appsecret_proof = calculate_proof(username)

    local expires = 3600 * 24  -- 1 day
    ngx.header['Set-Cookie'] = "alphero_username=" .. username .. "; path=/; Expires=" .. ngx.cookie_time(ngx.time() + expires)
    ngx.header['Set-Cookie'] = "alphero_proof=" .. appsecret_proof .. "; path=/; Expires=" .. ngx.cookie_time(ngx.time() + expires)
    ngx.exit(ngx.HTTP_OK)

end


function calculate_proof(username)
    local APPSECRETID = "T*QrEQ(FyGxmj%Izz(>d-=EbOahccv^N<iQ+q6Xdi^sE3mKAYt[W.KuV}O^]pw="
    local proof = ngx.hmac_sha1(APPSECRETID, username)        
    --local proof = crypto.hmac.digest("sha256", username, APPSECRETID, false)
    return ngx.encode_base64(proof)
end