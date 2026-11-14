# Dev_Sec_CSharp — SecurityWorkspace portfolio boundary (2026-11-14)

**Scope:** GitHub source-tree/README/manifest review only, without code execution or network-credential testing. Not a production attestation. [Central evidence-backed matrix](https://github.com/devwebsec/DESIGN-BY-SECURITY/blob/docs/portfolio-dependency-graph-20261114/docs/SECURITYWORKSPACE-CROSS-REPO-DEPENDENCY-AUDIT-20261114.md).

## XDEP-H02 — HIGH, main evidence

- `src/MySecureApp/Program.cs` implements JWT Bearer configuration with issuer/audience/lifetime/signing-key validation, Serilog, Swagger in Development, CORS, HTTP security headers.
- `src/MySecureApp/MySecureApp.csproj`: `net8.0`, packages `Microsoft.AspNetCore.Authentication.JwtBearer@8.0.8`, `Serilog.AspNetCore@8.0.2`, `Swashbuckle.AspNetCore@6.7.3`. This source check **does not prove runtime authn tests or deployment**.
- Git tree has **no** root Dockerfile, no `k8s/`, no Jenkinsfile, no Vaultwarden client. README Docker/Kubernetes commands are **unsupported in main**. A real external Jenkins/Vaultwarden deployment cannot be inferred from the README.
- `.github/workflows/security.yml` repeats root `name/on/jobs` and `permissions` keys. The declared scans may be ignored/invalid due to duplicate YAML semantics; actual CI status needs run evidence. `.github/workflows/ci.yml` uses floating actions and optional SonarQube secrets (presence not verified).
- **Fix gate:** separate reviewed code PR for one valid workflow with unique keys and pinned actions, real test project + trusted DAST target, Dockerfile/K8s if required, secrets via approved owner; run `dotnet restore/build/test` and inspect GitHub Actions. Do **not** run DAST against `staging.example.com` or assume production credentials.

## Relationships / non-inheritance

- [DESIGN-BY-SECURITY](https://github.com/devwebsec/DESIGN-BY-SECURITY) owns design/governance, but sharing a GitHub account does **not** establish CI import, runtime calls, API tokens or deployment.
- [WAZUH](https://github.com/devwebsec/WAZUH) host L3 Hotfix002 `deployment/smoke/SOAK10=PASS` is operator-reported and separate; `LIVE_E2E=NOT_ATTESTED`. This repository has **no attested production Wazuh dependency**.
- [Security Copilot](https://github.com/devwebsec/security-copilot-local-agent) and [Developer Copilot](https://github.com/devwebsec/developer-coding-copilot-local-agent) are independently scoped, not inherited SDKs or approval authorities.
- GitHub Project #1 membership, Gitea mirror, GitHub About metadata and transitive dependency vulnerabilities were not verified in this review.

## Proposed GitHub About description (not applied)

> Учебный ASP.NET Core 8 DevSecOps-образец; JWT/Serilog/Swagger; HIGH: security.yml и Docker/K8s evidence требуют исправления.

**Decision:** preserve repository history. Mark unsupported statements `HISTORICAL/UNVERIFIED`, require owner-reviewed source+CI changes before a claim of PASS. No merge, clean-up, rebranding, or auto-archive performed.
